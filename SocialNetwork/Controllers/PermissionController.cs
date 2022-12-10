using System.Threading.Tasks;
using SocialNetwork.Commons.CustomAttribute;
using SocialNetwork.Models.DTOs.Requests;
using SocialNetwork.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SocialNetwork.Controllers
{
    [Authorize]
    [Permission("MANAGE_PERMISSION")]
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : Controller
    {
        private readonly IPermissionService _permissionService;
        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpPost("credential")]
        // api/permission/credential
        public async Task<IActionResult> AddCredential(CredentialRequest req)
        {
            var rs = await _permissionService.AddCredential(req);
            if (!rs.IsSuccess)
            {
                return BadRequest(rs.ErrorMessage);
            }

            return Ok();
        }
       
        [HttpDelete("credential")]
        // api/permission/credential
        public async Task<IActionResult> RemoveCredential(CredentialRequest req)
        {
            var rs = await _permissionService.RemoveCredential(req);
            if (!rs.IsSuccess)
            {
                return BadRequest(rs.ErrorMessage);
            }

            return Ok();
        }
    }
}
