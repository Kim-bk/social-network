using SocialNetwork.Models.DAL;
using SocialNetwork.Models.DAL.Interfaces;
using SocialNetwork.Models.DTOs.Requests;
using SocialNetwork.Models.DTOs.Responses.Base;
using SocialNetwork.Services.Base;
using System.Threading.Tasks;
using System;
using SocialNetwork.Models;
using SocialNetwork.Models.DTOs.Responses;
using SocialNetwork.Services.Interfaces;

namespace SocialNetwork.Services
{
    public class UserGroupService : BaseService, IUserGroupService
    {
        private readonly IUserGroupRepository _userGroupRepository;
        public UserGroupService(IUserGroupRepository userGroupRepository, IUnitOfWork unitOfWork
                    , IMapperCustom mapper) : base(unitOfWork, mapper)
        {
            _userGroupRepository = userGroupRepository;
        }

        public async Task<GeneralResponse> UpdateUserGroup(UserGroupRequest req)
        {
            try
            {
                // 1. Find User Group
                var userGroup = await _userGroupRepository.FindAsync(ug => ug.Id == req.UserGroupId);
                if (userGroup == null)
                {
                    return new GeneralResponse
                    {
                        IsSuccess = false,
                        ErrorMessage = "Không tìm thấy tên quyền " + req.Name + " !"
                    };
                }

                // 2. Update that User Group
                userGroup.Name = req.Name;
                _userGroupRepository.Update(userGroup);
                await _unitOfWork.CommitTransaction();
                return new GeneralResponse
                {
                    IsSuccess = true
                };


            }
            catch (Exception e)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    ErrorMessage = e.Message
                };
            }
        }
        public async Task<GeneralResponse> AddUserGroup(string userGroupName)
        {
            try
            {
                // 1. Validate
                if (string.IsNullOrEmpty(userGroupName))
                {
                    return new GeneralResponse
                    {
                        IsSuccess = false,
                        ErrorMessage = "Cú pháp không hợp lệ !"
                    };
                }

                var userGroup = await _userGroupRepository.FindAsync(ug => ug.Name == userGroupName);
                if (userGroup != null && userGroup.IsDeleted == true)
                {
                    userGroup.IsDeleted = false;
                    return new GeneralResponse
                    {
                        IsSuccess = true,
                    };
                }

                var newUserGroup = new UserGroup
                {
                    Name = userGroupName,
                    IsDeleted = false,
                };
                await _userGroupRepository.AddAsync(newUserGroup);
                await _unitOfWork.CommitTransaction();
                return new GeneralResponse
                {
                    IsSuccess = true,
                };
            }
            catch (Exception e)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    ErrorMessage = e.Message,
                };
            }
        }

        public async Task<GeneralResponse> DeleteUserGroup(int userGroupId)
        {
            try
            {
                var userGroup = await _userGroupRepository.FindAsync(ug => ug.Id == userGroupId && ug.IsDeleted == false);
                userGroup.IsDeleted = true;

                await _unitOfWork.CommitTransaction();
                return new GeneralResponse
                {
                    IsSuccess = true,
                };
            }

            catch (Exception e)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    ErrorMessage = e.Message
                };
            }
        }

        public async Task<UserGroupResponse> GetUserGroups()
        {
            try
            {
                var rs = await _userGroupRepository.GetAll();
                return new UserGroupResponse
                {
                    IsSuccess = true,
                    UserGroups = rs
                };

            }
            catch (Exception e)
            {
                return new UserGroupResponse
                {
                    IsSuccess = false,
                    ErrorMessage = e.Message
                };
            }
        }
    }
}
