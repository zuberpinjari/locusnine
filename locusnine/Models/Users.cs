using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace locusnine.Models
{
    public class Users
    {
        public string Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string Roletype { get; set; }
        public string Status { get; set; }
    }
}
