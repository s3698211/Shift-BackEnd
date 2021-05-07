using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Shift_backend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Shift_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        
        
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;



        public UserController( UserManager<User> userManager, IUserService userService)
        {
            
            _userManager = userManager;
            _userService = userService;
        }

        
        [HttpGet, Authorize]
        public IActionResult GetShifts()
        {
            try
            {
                var currentUserID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var shifts = _userService.getShiftsOfUser(currentUserID);

                return Ok(shifts);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, ex);
            }
        }
    }
}
