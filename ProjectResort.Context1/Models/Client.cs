using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace ProjectResort.Context1.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required]
        public int KOD { get; set; }

        [Required]
        public string FIO { get; set; }

        [Required]
        public string Passport { get; set; }

        [Required]
        public DateTimeOffset DateBirth { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public override string ToString()
        {
            return $"{FIO}";
        }
    }
}
