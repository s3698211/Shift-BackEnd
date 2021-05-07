using AutoMapper;
using Contracts;
using Entities;
using Entities.DTO;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Shift_backend.Controllers
{
    [ApiController]
    
    [Route("[controller]")]
    public class ShiftController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly RepositoryContext _repoContext;
        



        public ShiftController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, UserManager<User> userManager, RepositoryContext repoContext)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _repoContext = repoContext;
        }

       

        [HttpGet ,Authorize]
        public IActionResult GetShifts()
        {
            try
            {
                var shifts = _repository.Shift.GetAllShifts(trackChanges: false);                
                
                return Ok(shifts);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetShifts)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}"), Authorize]
        public IActionResult GetShift(string id)
        {
            var shift = _repository.Shift.GetShift(id, trackChanges: false);
            if(shift == null)
            {
                _logger.LogInfo($"Shift with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {                
                return Ok(shift);
            }
        }

        [HttpPost, Authorize]
        public IActionResult CreateShift([FromBody] Shift shift)
        {
            if(shift == null)
            {
                _logger.LogError("Object sent from client is null");
                return BadRequest("Shift object is null");
            }
            var tempShift = _repository.Shift.GetShift(shift.Id, trackChanges: false);

            var currentUser = _repoContext.Users.First(user => user.UserName.Equals(shift.StaffName));           

            if (tempShift != null)
            {
                return BadRequest("ShiftId already exist");
            }
            else
            {
                
                _repository.Shift.CreateShift(shift, currentUser.Id);
                _repository.Save();
                
                return Ok();
            }
        }

        [HttpDelete("{id}")]        
        public IActionResult DeleteShift(string id)
        {
            var shift = _repository.Shift.GetShift(id, trackChanges: false);
            if (shift == null)
            {
                _logger.LogInfo($"Shift with id: {id} does not exist in the database");
                return NotFound();
            }
            else
            {
                _logger.LogInfo("Ok");
                _repository.Shift.DeleteShift(shift);
                _repository.Save();
                return Ok("Deleted Sucessful");
            }
           
        }
        [HttpPut("{id}")]

        public IActionResult UpdateShift(string id, [FromBody] Shift shift)
        {
            if(shift == null)
            {
                return BadRequest("Shift sent from the client is null");
            }

            var tempShift = _repository.Shift.GetShift(id, trackChanges: true);
            
            if(tempShift == null)
            {
                return BadRequest($"Shift with {id} does not exist in the database");
            }
            _repository.Shift.UpdateShift(shift);
            
            _repository.Save();
            return Ok(shift);
        }

    }
}
