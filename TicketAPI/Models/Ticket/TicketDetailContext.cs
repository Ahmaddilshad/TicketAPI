using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketAPI.Models.Ticket
{
    public class TicketDetailContext: IdentityDbContext
    {
        public TicketDetailContext(DbContextOptions<TicketDetailContext>options):base(options)
        {

        }
        public DbSet<CreateTicket> CreateTickets { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
    }
}
