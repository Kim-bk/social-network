using SocialNetwork.Commons.CustomAttribute;
using SocialNetwork.Models.DTOs.Requests;
using SocialNetwork.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SocialNetwork.Controllers
{
    [Authorize]
    [Permission("MANAGE_PERMISSION")]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost]
        // api/role
        public async Task<IActionResult> CreateRole([FromBody] string roleName)
        {
            var rs = await _roleService.CreateRole(roleName);
            if (!rs.IsSuccess)
            {
                return BadRequest(rs.ErrorMessage);
            }

            return Ok("Creata role " + roleName + " success !");
        }

        [HttpPut]
        // api/role
        public async Task<IActionResult> UpdateRole(RoleRequest req)
        {
            var rs = await _roleService.UpdateRole(req);
            if (!rs.IsSuccess)
            {
                return BadRequest(rs.ErrorMessage);
            }

            return Ok("Update success !");
        }

        [HttpDelete("{roleId:int}")]
        // api/role/{roleId}
        public async Task<IActionResult> DeleteRole(int roleId)
        {
            var rs = await _roleService.DeleteRole(roleId);
            if (!rs.IsSuccess)
            {
                return BadRequest(rs.ErrorMessage);
            }

            return Ok("Delete success !");
        }
    }
}
