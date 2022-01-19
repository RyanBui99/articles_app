using System;
using System.Linq;
using System.Threading.Tasks;
using articles_app.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace articles_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public AuthenticationController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existingUser = await _userManager.FindByEmailAsync(user.Email);

                    // Check if email already exusts
                    if (existingUser != null)
                    {
                        return BadRequest(new ResponseToClient { Message = "Username already exists" });
                    }

                    var newUser = new IdentityUser() { Email = user.Email, UserName = user.Email };
                    var userCreation = await _userManager.CreateAsync(newUser, user.Password);
                    if (userCreation.Succeeded)
                    {
                        var doesUserRoleExist = await _roleManager.RoleExistsAsync("user");

                        // Create regular user role
                        if (!doesUserRoleExist)
                        {
                            await _roleManager.CreateAsync(new IdentityRole() { Id = "vd376a8f-9eab-4bb9-9fca-30b01540f446", Name = "user" });
                        }

                        await _userManager.AddToRoleAsync(newUser, user.Role);
                        return Ok();
                    } else {
                        return BadRequest(new ResponseToClient { Message = "Unable to create user" });
                    }
                }
                return BadRequest(new ResponseToClient { Message = "Oops, something went wrong..." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existingUser = await _userManager.FindByEmailAsync(user.Email);
                    var isCorrect = await _userManager.CheckPasswordAsync(existingUser, user.Password);

                    // Check if user exists by finding their email
                    if (existingUser == null || !isCorrect)
                    {
                        // Add multipurpose message to make it harder for attacker
                        return BadRequest(new ResponseToClient { Message = "Invalid username or Incorrect password"});
                    }

                    var loggedInUser = await _userManager.FindByEmailAsync(user.Email);
                    var role = await _userManager.GetRolesAsync(loggedInUser);

                    return Ok(new ResponseToClient { Username = loggedInUser.UserName, Id = loggedInUser.Id, Role = role.First() });
                }
                return BadRequest(new ResponseToClient { Message = "Can't leave fields empty"});
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
