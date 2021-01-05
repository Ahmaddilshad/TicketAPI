using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketAPI.Models;
using Microsoft.AspNetCore.Identity;
using TicketAPI.Models.Ticket;

namespace AppointmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class IdentityController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly TicketDetailContext _context;

        public IdentityController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, TicketDetailContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }


        [HttpPost("login")]

        public async Task<IActionResult> Login(UserDetail userDetail)
        {
            var userFromDb = await _userManager.FindByNameAsync(userDetail.Username);

            if (userFromDb == null)
            {
                return BadRequest();
            }

            var result = await _signInManager.CheckPasswordSignInAsync(userFromDb, userDetail.Password, false);

            if (!result.Succeeded)
            {
                return BadRequest();

            }
            return Ok(new
            {
                result = result,
                
                email = userFromDb.Email,
                username =userFromDb.UserName,
                uniqueid = userFromDb.Id,
                userid = userFromDb.Id

            });
        }

        [HttpPost("signup")]

        public async Task<IActionResult> signup(UserDetail userDetail)
        {
            var userToCreate = new IdentityUser
            {
               
                UserName = userDetail.Username,
                Email = userDetail.Email
            };

            var result = await _userManager.CreateAsync(userToCreate, userDetail.Password);


            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

          [HttpGet("{id}")]
        public IEnumerable<CreateTicket>UserTickets([FromRoute] string id)
        {
            var ticket = _context.CreateTickets.Where(x => x.UserId == id);
            
            return ticket;
        } 

    
    }
}