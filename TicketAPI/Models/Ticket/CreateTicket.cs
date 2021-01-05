using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TicketAPI.Models.Ticket
{
    public class CreateTicket
    {
        [Key]
        public int TicketId { get; set; }

        [Column(TypeName ="nvarchar(100)")]
        public string Summary { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Description { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Complaint { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string UserId { get; set; }


    }
}
