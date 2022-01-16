using System;
using System.Linq;
using System.Threading.Tasks;
using articles_app.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace articles_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController :ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AuthenticationController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Route("userData")]
        public IActionResult GetUsers()
        {
            var users = _userManager.Users.ToArray();
            return Ok(users);
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
                    if (existingUser == null)
                    {
                        return BadRequest();
                    }

                    // Check if pass incorrect
                    if (!isCorrect)
                    {
                        return BadRequest();
                    }
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
