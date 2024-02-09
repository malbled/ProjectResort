using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectResort.Context1.Models
{
    public class Equipment
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Quantity { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public Equipment()
        {
            Orders = new List<Order>();
        }
    }
}
