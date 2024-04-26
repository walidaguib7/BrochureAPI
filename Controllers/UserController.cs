using BrochureAPI.Dtos.User;
using BrochureAPI.Interfaces;
using BrochureAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace BrochureAPI.Controllers
{

    [Route("api/user")]
    [ApiController]
    
    public class UserController(UserManager<User> userManager, ITokenService tokenService , SignInManager<User> manager) : ControllerBase
    {
        private readonly UserManager<User> userManager = userManager;
        private readonly ITokenService _tokenService = tokenService;
        private readonly SignInManager<User> _manager = manager;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid");
                }

                


                var user = new User
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email
                    
                };

                var createdUser = await userManager.CreateAsync(user, registerDto.Password);
                if (createdUser.Succeeded)
                {
                    // add user role to user created now
                    var Roles = await userManager.AddToRoleAsync(user, "user");
                    if (Roles.Succeeded)
                    {
                        return Ok(
                            new NewUser
                            {
                                Email = user.Email,
                                UserName = user.UserName,
                                Token = _tokenService.CreateToken(user)
                            }
                            );
                    }
                    else
                    {
                        return StatusCode(500, Roles.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception ex)
            {
                // Log the exception for debugging
                Console.WriteLine("ay ki zebi");
                Console.WriteLine("ay ki zebi");
                return StatusCode(500, "An error occurred during registration.");
            }
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await userManager.Users.FirstOrDefaultAsync(u => u.UserName == loginDto.Username);
            if (user == null) return Unauthorized("Invalid username");
            var result = await _manager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded) return Unauthorized("Username / Password wrong , re-try!");

            return Ok(
                new NewUser
                {
                    UserName = loginDto.Username,
                    Email = user.Email,
                    Token = _tokenService.CreateToken(user)
                });
        }
    }
}