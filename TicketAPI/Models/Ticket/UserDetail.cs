using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TicketAPI.Models.Ticket
{
    public class UserDetail
    {
        [Key]
        public int UserId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Firstname { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Lastname { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(100)")]

        public string Phone { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Username { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Password { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Confirmpassword { get; set; }
        
    }
}
