using SocialNetwork.Models;
using SocialNetwork.Models.DAL;
using SocialNetwork.Models.DAL.Interfaces;
using SocialNetwork.Models.DAL.Repositories;
using SocialNetwork.Models.DTOs;
using SocialNetwork.Models.DTOs.Requests;
using SocialNetwork.Services.Base;
using SocialNetwork.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetwork.Services
{
    public class FriendService : BaseService, IFriendService
    {
        private readonly IFriendRepository _friendRepo;
        private readonly IUserRepository _userRepo;
        public FriendService(IFriendRepository friendRepo, IUnitOfWork unitOfWork
            , IMapperCustom mapper, IUserRepository userRepo) : base(unitOfWork, mapper)
        {
            _friendRepo = friendRepo;
            _userRepo = userRepo;
        }

        public async Task<bool> AddFriend(int userId, int friendId)
        {
            await _unitOfWork.BeginTransaction();
            var friend = new Friend()
            {
                CreatedDate = DateTime.Now,
                Status = false,
                SourceId = userId,
                TargetId = friendId,
            };
            await _friendRepo.AddAsync(friend);
            await _unitOfWork.CommitTransaction();
            return true;
        }

        public async Task<List<UserDTO>> GetFriends(int userDTO)
        {
            var listIds = await _friendRepo.GetFriendsOfUser(userDTO);
            var listUser = await _userRepo.GetListUsers(listIds);
            return _mapper.MapUsers(listUser);
        }

        public async Task<List<UserDTO>> GetInvatitationFriends(int userDTO)
        {
            var listIds = await _friendRepo.GetInvitationFriendsOfUser(userDTO);
            var listUser = await _userRepo.GetListUsers(listIds);
            return _mapper.MapUsers(listUser);
        }

        public async Task<bool> ManageFriend(int userId, FriendRequest req)
        {
            await _unitOfWork.BeginTransaction();
            var friend = await _friendRepo.FindAsync(us => (us.SourceId == req.FriendId || us.SourceId == userId) 
                                                    && (us.TargetId == userId || us.TargetId == req.FriendId));
            if (req.Action == "approve")
            {
                friend.Status = true;
                friend.ApprovedDate = DateTime.Now;
            }
            else
            {
                friend.Status = false;
                friend.DeniedDate = DateTime.Now;
            }

            await _unitOfWork.CommitTransaction();
            return true;
        }

        public async Task<List<UserDTO>> SearchFriend(int userId, string userName)
        {
            var rs = await _userRepo.SearchFriend(userName);

            var isFriend = false;
            var listUser = new List<UserDTO>();
            foreach (var u in rs)
            {
                var check = await _friendRepo.CheckFriend(userId, u.Id);
                var check2 = await _friendRepo.CheckFriend(u.Id, userId);
                if (check || check2)
                    isFriend = true;

                var user = new UserDTO
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    Address = u.Address,
                    PhoneNumber = u.PhoneNumber,
                    IsFriend = isFriend,
                };
                listUser.Add(user);
            }
            return listUser;
        }
    }
}
