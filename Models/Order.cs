using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class Order : BaseEntity
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        [Display(Name = "Order Quantity")]
        [Range(1, 100)]
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [Display(Name = "Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}