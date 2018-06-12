using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class Product : BaseEntity
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        public string Name { get; set; }
        [Required]
        [MinLength(8)]
        [Display(Name = "Product Description")]
        public string Description { get; set; }
        [Required]
        [DataType("int")]
        [Range(1, 100)]
        [Display(Name = "Product Quantity")]
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Order> Shipments { get; set; }
        public Product()
        {
            Shipments = new List<Order>();
        }
    }
}