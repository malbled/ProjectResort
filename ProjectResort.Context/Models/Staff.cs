using ProjectResort.Context.Enum;
using System.ComponentModel.DataAnnotations;

namespace ProjectResort.Context.Models
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

        [Required]
        public DateTimeOffset DateLog { get; set; }

        [Required]
        public TypeEntry TypeEntry { get; set; }
    }
}
