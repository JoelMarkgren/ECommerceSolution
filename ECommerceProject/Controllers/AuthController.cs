using ECommerceProject.Dto;
using ECommerceProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace ECommerceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            try
            {
                var user = new User()
                {
                    UserName = userDto.Email.ToLower(),
                    Email = userDto.Email.ToLower(),
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName
                };
                var result = await userManager.CreateAsync(user, userDto.Password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }
                await userManager.AddToRoleAsync(user, "User");

                return Accepted();
            }
            catch (Exception ex)
            {
                return Problem($"Something went wrong in the {nameof(Register)}", statusCode: 500);
            }
            
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginUserDto loginUserDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var user = await userManager.FindByEmailAsync(loginUserDto.Email.ToLower());
                if (user == null)
                {
                    return NotFound("User not found");
                }
                if (!user.EmailConfirmed)
                {
                    return Unauthorized("Please confirm your Email");
                }

                var passwordValid = await userManager.CheckPasswordAsync(user, loginUserDto.Password);
                if (!passwordValid)
                {
                    return Unauthorized("Invalid Password");
                }
                return Accepted();
            }
            catch (Exception ex)
            {
                return Problem($"Something went wrong in the {nameof(Login)}", statusCode: 500);
            }
        }
    }
}
