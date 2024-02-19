using ProjectResort.Context1.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectResort.Context1.Models
{
    public class Staff
    {
        public int Id { get; set; }

        [Required]
        public Post Post { get; set; }

        [Required]
        public string FIO { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        public byte[] Image { get; set; }
    }
}
