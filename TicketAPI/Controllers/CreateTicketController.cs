using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketAPI.Models.Ticket;

namespace TicketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateTicketController : ControllerBase
    {
        private readonly TicketDetailContext _context;

        public CreateTicketController(TicketDetailContext context)
        {
            _context = context;
        }

        // GET: api/CreateTicket
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreateTicket>>> GetCreateTickets()
        {
            return await _context.CreateTickets.ToListAsync();
        }

        // GET: api/CreateTicket/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CreateTicket>> GetCreateTicket(int id)
        {
            var createTicket = await _context.CreateTickets.FindAsync(id);

            if (createTicket == null)
            {
                return NotFound();
            }

            return createTicket;
        }

        // PUT: api/CreateTicket/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCreateTicket(int id, CreateTicket createTicket)
        {
            if (id != createTicket.TicketId)
            {
                return BadRequest();
            }

            _context.Entry(createTicket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CreateTicketExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CreateTicket
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CreateTicket>> PostCreateTicket(CreateTicket createTicket)
        {
            _context.CreateTickets.Add(createTicket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCreateTicket", new { id = createTicket.TicketId }, createTicket);
        }

        // DELETE: api/CreateTicket/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCreateTicket(int id)
        {
            var createTicket = await _context.CreateTickets.FindAsync(id);
            if (createTicket == null)
            {
                return NotFound();
            }

            _context.CreateTickets.Remove(createTicket);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CreateTicketExists(int id)
        {
            return _context.CreateTickets.Any(e => e.TicketId == id);
        }
    }
}
