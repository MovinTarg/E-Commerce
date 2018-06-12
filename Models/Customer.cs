using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class Customer : BaseEntity
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$")]
        [Display(Name = "Customer Name")]
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Order> Purchases { get; set; }
 
        public Customer()
        {
            Purchases = new List<Order>();
        }
    }
}