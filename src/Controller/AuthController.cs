using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using app.src.Dto;
using app.src.Model;
using app.src.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace app.src.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        public static User user = new();
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
           var user = await authService.RegisterAsync(request);
           if (user == null){ return BadRequest("UserName Already Exists");}

           return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenResponseDto>> Login(UserDto request)
        {  
            var result = await authService.LoginAsync(request);
            if(result == null){ return BadRequest("Invalid Credentials");}

            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        public IActionResult AuthenticatedOnlyEndpoint()
        {
            return Ok("You are Authenticated!");
        }
        //("Admin,User") mais quer uma;
        [Authorize(Roles = "Admin")]
        [HttpGet("admin-only")]
        public IActionResult AdminOnlyEndpoint()
        {
            return Ok("You are Authenticated!");
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<TokenResponseDto>> RefreshToken(RefreshTokenRequestDto request)
        {
            var result = await authService.RefreshTokensAsync(request);
            
            if( result == null ||
                result.AccessToken is null ||
                result.RefreshToken is null
            )   return Unauthorized("Invalid Request Token!");

            return Ok(result);
        }
    }
}