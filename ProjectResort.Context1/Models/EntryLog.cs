using ProjectResort.Context1.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectResort.Context1.Models
{
    public class EntryLog
    {
        public int Id { get; set; }

        [Required]
        public DateTimeOffset DateLog { get; set; }

        [Required]
        public string StaffKod { get; set; }
        public virtual Staff Staff { get; set; }

        [Required]
        public TypeEntry TypeEntry { get; set; }
    }
}
