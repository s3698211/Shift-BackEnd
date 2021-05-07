﻿using AutoMapper;
using Contracts;
using Entities.DTO;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace Shift_backend.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationManager _authManager;
        private readonly SignInManager<User> _signInManager;
        public AuthenticationController(ILoggerManager logger, IMapper mapper,
        UserManager<User> userManager, IAuthenticationManager authManager, SignInManager<User> signInManager)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _authManager = authManager;
            _signInManager = signInManager;
        }

        [HttpPost]
       
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto
        userForRegistration)
        {
            
            var user = _mapper.Map<User>(userForRegistration);
            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            
            await _userManager.AddToRolesAsync(user, userForRegistration.Roles);
            return StatusCode(201);
        }

        
        [HttpPost("login")]
        
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto
user)
        {            if (!await _authManager.ValidateUser(user))
            {
                _logger.LogWarn($"{nameof(Authenticate)}: Authentication failed. Wrong user name or password.");
                
            return Unauthorized();
            }
            return Ok(new { Token = await _authManager.CreateToken() });
        }

        [HttpPost("logout")]

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
    }
}
