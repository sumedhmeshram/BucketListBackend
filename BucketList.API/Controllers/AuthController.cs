using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using BucketList.Common.Filters;
using BucketList.Common.StaticConstants;
using BucketList.Entity.Model.Auth;
using BucketList.ViewModel;
using BucketList.ViewModel.Auth;
using BucketList.ViewModel.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Serilog;

namespace BucketList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private IPasswordHasher<AppUser> _passwordHasher;
        private ILogger<AuthController> _logger;


        public AuthController(UserManager<AppUser> userManager,
             IPasswordHasher<AppUser> passwordHasher, ILogger<AuthController> logger)
        {
            _userManager = userManager;
            _logger = logger;
            _passwordHasher = passwordHasher;
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var user = new AppUser()
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            var jwtSecurityToken = await generateToken(user);
            var tokenVM = new TokenVM
            {
                AccessToken = jwtSecurityToken,
                ExpiresIn = (int)TimeSpan.FromDays(Constants.TokenExpiryDays).TotalSeconds,
                UserInfo = Mapper.Map<UserVM>(user)
            };
            return Ok(tokenVM);
        }
        [ValidateForm]
        [HttpPost("token")]
        public async Task<IActionResult> CreateToken([FromBody] LoginVM model)
        {
            var user = await _userManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                return Unauthorized();
            }
            if (_passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password) == PasswordVerificationResult.Success)
            {
                var jwtSecurityToken = await generateToken(user);
                var tokenVM = new TokenVM
                {
                    AccessToken = jwtSecurityToken,
                    ExpiresIn = (int)TimeSpan.FromDays(Constants.TokenExpiryDays).TotalSeconds,
                    UserInfo = Mapper.Map<UserVM>(user)
                };
                return Ok(tokenVM);
            }
            return Unauthorized();
        }

        private async Task<string> generateToken(AppUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);

            var claims = new[]
            {
                        new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email)
                    }.Union(userClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.TokenSecretKey));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: Constants.TokenIssuer,
                audience: Constants.TokenAudience,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(Constants.TokenExpiryDays),
                signingCredentials: signingCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

    }
}