using SocialNetwork.Models.DTOs.Requests;
using SocialNetwork.Commons.CustomAttribute;
using SocialNetwork.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SocialNetwork.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IAuthService _authService;
        private readonly IPermissionService _permissionService;
        public AdminController(IAdminService adminService, IAuthService authService
            , IPermissionService permissionService)
        {
            _adminService = adminService;
            _authService = authService;
            _permissionService = permissionService;
        }

        [Permission("MANAGE_PERMISSION")]
        [HttpGet("credentials/{userGroupId:int}")]
        public async Task<IActionResult> GetRolesOfUserGroup(int userGroupId)
        {
            var rs = await _adminService.GetRolesOfUserGroup(userGroupId);
            return Ok(rs);
        }

        [AllowAnonymous]        
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var rs = await _adminService.Login(request);
            if (rs.IsSuccess)
            {
                // 1. Get list credentials of admin
                var listCredentials = await _permissionService.GetCredentials(rs.User.Id);

                // 2. Authenticate admin
                var res = await _authService.Authenticate(rs.User, listCredentials);
                if (res.IsSuccess)
                    return Ok(res);

                else
                    return BadRequest(res.ErrorMessage);
            }

            return BadRequest(rs.ErrorMessage);
        }

    }
}
