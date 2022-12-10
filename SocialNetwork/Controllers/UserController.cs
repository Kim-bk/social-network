using System;
using System.Security.Claims;
using System.Threading.Tasks;
using SocialNetwork.Models.DTOs.Requests;
using SocialNetwork.Models.DTOs;
using SocialNetwork.Models.DTOs.Requests;
using SocialNetwork.Services;
using SocialNetwork.Services.Interfaces;
using SocialNetwork.Services.TokenGenerators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        private readonly RefreshTokenGenerator _refreshTokenGenerator;
        private readonly IPermissionService _permissionService;

        public UserController(IUserService userService, IAuthService authService
                 , RefreshTokenGenerator refreshTokenGenerator, IPermissionService permissionService)
        {
            _userService = userService;
            _authService = authService;
            _refreshTokenGenerator = refreshTokenGenerator;
            _permissionService = permissionService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var rs = await _userService.FindById(userId);
            if (rs.IsSuccess)
            {
                return Ok(rs.UserDTO);
            }

            return BadRequest(rs.ErrorMessage);
        }


        [HttpPost("login")]
        // api/user/login
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var rs = await _userService.Login(request);
                if (rs.IsSuccess)
                {
                    // 1. Get list credentials of user
                    var listCredentials = await _permissionService.GetCredentials(rs.User.Id);

                    // 2. Authenticate user
                    var res = await _authService.Authenticate(rs.User, listCredentials);
                    if (res.IsSuccess)
                        return Ok(res);

                    else
                        return BadRequest(res.ErrorMessage);
                }

                return BadRequest(rs.ErrorMessage);
            }
            catch
            {
                throw;
            }
         
        }

        [HttpPost("logout")]
        // api/User/logout
        public async Task<IActionResult> Logout()
        {
            int userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            _ = await _userService.Logout(userId);
            return Ok("Đăng xuất thành công !");
        }

        [HttpPost("refresh-token")]
        // api/User/refresh-token
        public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequest refreshRequest)
        {
            try
            {
                var rs = await _refreshTokenGenerator.Refresh(refreshRequest.Token);
                if (rs.IsSuccess)
                {
                    // 1. Get list credentials of user
                    var listCredentials = await _permissionService.GetCredentials(rs.User.Id);

                    // 2. Authenticate user
                    var responseTokens = await _authService.Authenticate(rs.User, listCredentials);
                    return Ok(responseTokens);
                }

                return BadRequest(rs.ErrorMessage);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpPost("register")]
        // api/user/register
        public async Task<IActionResult> Register([FromBody] RegistRequest request)
        {
            var rs = await _userService.Register(request);

            if (rs.IsSuccess)
            {
                return Ok("Vui lòng vào Email kiểm tra tin nhắn !");
            }

            return BadRequest(rs.ErrorMessage);
        }

        [HttpGet("verify-User")]
        // api/user/verify-User?code
        public async Task<IActionResult> VerifyUser([FromQuery] string code)
        {
            var rs = await _userService.CheckUserByActivationCode(new Guid(code));
            if (rs)
            {
                return Ok("Xác thực thành công !");
            }
            return BadRequest("Xác thực thất bại !");
        }

        [HttpPost("forgot-password")]
        // api/user/forgot-password
        public async Task<IActionResult> ForgotPassword(ForgotPasswordRequest request)
        {
            var rs = await _userService.ForgotPassword(request.Email);
            if (rs.IsSuccess)
            {
                return Ok("Kiểm tra Email của bạn để thay đổi mật khẩu !");
            }
            return BadRequest(rs.ErrorMessage);
        }

        #region Reset Password

        [HttpPost("reset-password")]
        // api/user/reset-password
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest request)
        {
            var rs = await _userService.ResetPassword(request);
            if (rs.IsSuccess)
            {
                return Ok("Bạn đã thay đổi mật khẩu thành công !");
            }
            return BadRequest(rs.ErrorMessage);
        }


        [HttpGet("reset-password")]
        // api/user/reset-password?code 
        public async Task<IActionResult> ResetPassword([FromQuery] string code)
        {
            var rs = await _userService.GetUserByResetCode(new Guid(code));
            if (rs)
            {
                // Redirect sang trang cập nhật mật khẩu, gửi kèm theo code
                return Redirect("https://2clothy.vercel.app/resetpassword?code=" + code);
            }
            return BadRequest("Không tìm thấy tài khoản tương ứng !");
        }   
        #endregion

        [Authorize]
        [HttpPut]
        // api/user/
        public async Task<IActionResult> UpdateUser([FromBody] UserRequest request)
        {
            var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var rs = await _userService.UpdateUser(request,userId);
            if (rs.IsSuccess)
            {
                return Ok("Cập nhật người dùng thành công!");
            }
            return BadRequest(rs.ErrorMessage);
        }
      
    }
}
