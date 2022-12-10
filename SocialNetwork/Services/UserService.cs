using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SocialNetwork.Models.DTOs.Requests;
using SocialNetwork.Models;
using SocialNetwork.Models.DAL;
using SocialNetwork.Models.DAL.Interfaces;
using SocialNetwork.Models.DAL.Repositories;
using SocialNetwork.Models.DTOs;
using SocialNetwork.Models.DTOs.Requests;
using SocialNetwork.Models.DTOs.Responses;
using SocialNetwork.Services.Base;
using SocialNetwork.Services.Interfaces;


namespace SocialNetwork.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly Encryptor _encryptor;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _map;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, Encryptor encryptor
                    , IEmailSender emailSender, IMapperCustom mapper
                    , IRefreshTokenRepository refreshTokenRepossitory, IMapper map) : base(unitOfWork, mapper)
        {
            _userRepository = userRepository;
            _encryptor = encryptor;
            _emailSender = emailSender;
            _refreshTokenRepository = refreshTokenRepossitory;
            _map = map;
        }

        public async Task<UserResponse> FindById(int userId)
        {
            try
            {
                var user = await _userRepository.FindAsync(us => us.Id == userId);
                var userDTO = _map.Map<User, UserDTO>(user);
                return new UserResponse
                {
                    IsSuccess = true,
                    UserDTO = userDTO
                };
            }

            catch (Exception e)
            {
                return new UserResponse
                {
                    ErrorMessage = e.Message,
                    IsSuccess = false
                };
            }
        }
        public async Task<bool> Logout(int userId)
        {
            try
            {
                await _unitOfWork.BeginTransaction();
                await _refreshTokenRepository.DeleteAll(userId);
                await _unitOfWork.CommitTransaction();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }    
        public async Task<bool> CheckUserByActivationCode(Guid activationCode)
        {
            var user = await _userRepository.FindAsync(us => us.ActivationCode == activationCode);
            if (user == null)
                return false;

            user.IsActivated = true;
            await _unitOfWork.CommitTransaction();
            return true;
        }

        public async Task<UserResponse> ForgotPassword(string userEmail)
        {
            try
            {
                // 1. Find user by email
                var user = await _userRepository.FindAsync(us => us.Email == userEmail && us.IsActivated == true);
                
                // 2. Check
                if (user == null)
                {
                    return new UserResponse
                    {
                        IsSuccess = false,
                        ErrorMessage = "Không thể tìm thấy Email được đăng ký !",
                    };
                }

                // 3. Generate reset password code to validate
                var resetCode = Guid.NewGuid();
                user.ResetPasswordCode = resetCode;

                // 3. Send email to user to reset password
                await _emailSender.SendEmailVerificationAsync(userEmail, resetCode.ToString(), "reset-password");
                await _unitOfWork.CommitTransaction();

                return new UserResponse
                {
                    IsSuccess = true,
                };
            }
            catch (Exception e)
            {
                return new UserResponse
                {
                    IsSuccess = false,
                    ErrorMessage = e.Message,
                };
            }
        }

        public async Task<bool> GetUserByResetCode(Guid resetPassCode)
        {
            return await _userRepository.FindAsync(us => us.ResetPasswordCode == resetPassCode) != null;
        }

        public async Task<UserResponse> Login(LoginRequest req)
        {
            // 1. Find user by user name
            var user = await _userRepository.FindAsync(us => us.Email == req.Email);

            // 2. Check if user exist
            if (user == null)
            {
                return new UserResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "Không thể tìm thấy tài khoản !",
                };
            }

            // 3. Check if user is activated
            if (!user.IsActivated)
            {
                return new UserResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "Vui lòng kiểm tra Email đã đăng ký để kích hoạt tài khoản !",
                };
            }

            // 4. Check if login password match
            if (_encryptor.MD5Hash(req.Password) != user.Password)
            {
                return new UserResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "Sai mật khẩu hoặc tên đăng nhập !",
                };
            }

            return new UserResponse
            {
                User = user,
                IsSuccess = true
            };
        }

        public async Task<UserResponse> Register(RegistRequest req)
        {
            try
            {
                // 1. Check if duplicated User created
                var getUser = await _userRepository.FindAsync(us => us.Email == req.Email);
              
                if (getUser != null)
                {
                    return new UserResponse
                    {
                        IsSuccess = false,
                        ErrorMessage = "Email đã được sử dụng !",
                    };
                }

                // 2. Check pass with confirm pass
                if (!String.Equals(req.Password, req.ConfirmPassWord))
                {
                    return new UserResponse
                    {
                        IsSuccess = false,
                        ErrorMessage = "Mật khẩu xác nhận không khớp !",
                    };
                }

                await _unitOfWork.BeginTransaction();

                // 3. Create new User
                var user = new User
                {
                    Email = req.Email,
                    IsActivated = false,
                    ActivationCode = Guid.NewGuid(),
                    CreatedDate = DateTime.UtcNow.Date,
                    UserGroupId = 2,  // CUSTOMER

                    // 4. Encrypt password
                    Password = _encryptor.MD5Hash(req.Password),
                };

                // 5. Add user 
                await _userRepository.AddAsync(user);
                await _unitOfWork.CommitTransaction();

                // 6. Send an email activation
                await _emailSender.SendEmailVerificationAsync(user.Email, user.ActivationCode.ToString(), "verify-User");

                return new UserResponse
                {
                    IsSuccess = true,
                };
            }

            catch (Exception e)
            {
                return new UserResponse
                {
                    IsSuccess = false,
                    ErrorMessage = e.Message,
                };
            }
        }

        public async Task<UserResponse> ResetPassword(ResetPasswordRequest req)
        {
            try
            {
                // 1. Find user by reset password code
                var user = await _userRepository.FindAsync(us => us.ResetPasswordCode == new Guid(req.ResetPasswordCode) && us.IsActivated == true);

                // 2. Check
                if (user == null)
                {
                    return new UserResponse
                    {
                        IsSuccess = false,
                        ErrorMessage = "Không tìm thấy tài khoản !",
                    };
                }

                user.Password = _encryptor.MD5Hash(req.NewPassword);
                user.ResetPasswordCode = new Guid();

                await _unitOfWork.CommitTransaction();

                return new UserResponse
                {
                    IsSuccess = true,
                };
            }

            catch (Exception e)
            {
                return new UserResponse
                {
                    IsSuccess = false,
                    ErrorMessage = e.Message,
                };
            }
        }
        public async Task<UserResponse> UpdateUser(UserRequest req,int idUser)
        {
            try
            {
                var userReq = await _userRepository.FindAsync(it => it.Id == idUser);

                if(userReq == null)
                {
                    return new UserResponse
                    {
                        IsSuccess = false,
                        ErrorMessage = "Không tìm thấy tài khoản !",
                    };
                }
                await _unitOfWork.BeginTransaction();
                userReq.Name = req.Name;
                userReq.PhoneNumber = req.PhoneNumber;
                userReq.Address = req.Address;
                _userRepository.Update(userReq);
                await _unitOfWork.CommitTransaction();
                
                return new UserResponse
                {
                    IsSuccess = true,
                };
            }

            catch (Exception e)
            {
                return new UserResponse
                {
                    IsSuccess = false,
                    ErrorMessage = e.Message,
                };
            }
        }
    }
}
