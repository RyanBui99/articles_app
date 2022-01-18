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
