using ProjectResort.Context1.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectResort.Context1.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public string KOD { get; set; }

        [Required]
        public DateTimeOffset DateAdd { get; set; }

        [Required]
        public string ClientKod { get; set; }
        public virtual Client Client { get; set; }

        [Required]
        public Status Status { get; set; }

        public DateTimeOffset? DateEnd { get; set; }

        public decimal? TimeRental { get; set; }

        public decimal? TotalPrice { get; set; }

        public virtual ICollection<Service> Services { get; set; }

        public Order()
        {
            Services = new List<Service>();
        }
    }
}
