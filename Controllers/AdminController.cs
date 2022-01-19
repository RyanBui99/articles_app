using articles_app.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace articles_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController :  ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> GetUsersAsync()
        {
            var list = new List<Users>();

            foreach (var user in _userManager.Users.ToList())
            {
                var role = await _userManager.GetRolesAsync(user);
                list.Add(new Users()
                {
                    Username = user.UserName,
                    Role = role.First(),
                    Id = user.Id
                });
            }
            return Ok(RemoveLoggedInAdminFromList(list));
        }

        [HttpPut]
        [Route("updateUser/{id}")]
        public async Task<IActionResult> EditUser([FromBody] Users input, [FromRoute] string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var role = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRoleAsync(user, role.First()); // Temp delete role from user
            if (user == null)
            {
                return BadRequest(new ResponseToClient { Message = "User does not exist" });
            } else
            {
                user.Email = input.Username;
                user.UserName = input.Username;
                await _userManager.UpdateAsync(user);
                await _userManager.AddToRoleAsync(user, input.Role);
                return Ok(new ResponseToClient { Message = "User successfully updated"});
            }
        }

        [HttpDelete]
        [Route("deleteUser/{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return BadRequest(new ResponseToClient { Message = "User does not exist" });

            await _userManager.DeleteAsync(user);
            return Ok(new ResponseToClient { Message = "User successfully deleted" });
        }

        private List<Users> RemoveLoggedInAdminFromList(List<Users> UserList)
        {
            var originalAdminId = "a18be9c0-aa65-4af8-bd17-00bd9344e575";

            foreach (var user in UserList)
            {
                if (user.Id == originalAdminId)
                {
                    UserList.Remove(user);
                    return UserList;
                }
            }
            return UserList;
        }
    }
}
