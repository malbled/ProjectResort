﻿using System.ComponentModel.DataAnnotations;

namespace ProjectResort.Context.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string KOD { get; set; }

        [Required]
        public decimal Price { get; set; }

        public byte[] ImagePreview { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public Service()
        {
            Orders = new List<Order>();
        }
    }
}
