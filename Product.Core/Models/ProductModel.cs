using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Core.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public DateTime DateCreated { get; set; }
        public int AvailabilityStatus { get; set; }
        public int BrandId { get; set; }
    }
}
