using System;
using System.Threading.Tasks;
using SocialNetwork.Models.DTOs.Requests;
using SocialNetwork.Models;
using SocialNetwork.Models.DTOs.Responses;

namespace SocialNetwork.Services
{
    public interface IUserService
    {
        Task<UserResponse> Login(LoginRequest req);
        Task<UserResponse> Register(RegistRequest req);
        Task<UserResponse> UpdateUser(UserRequest req, int idUser);
        Task<bool> CheckUserByActivationCode(Guid activationCode);
        Task<UserResponse> ResetPassword(ResetPasswordRequest request);
        Task<UserResponse> ForgotPassword(string userEmail);
        Task<bool> GetUserByResetCode(Guid resetPassCode);
        Task<UserResponse> FindById(int userId);
        Task<bool> Logout(int userId);
    }
}
