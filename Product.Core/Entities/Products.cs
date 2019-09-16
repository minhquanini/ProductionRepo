using System;
using System.Collections.Generic;

namespace Product.Core.Entities
{
    public partial class Products
    {
        public Products()
        {
            Reviews = new HashSet<Reviews>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public DateTime DateCreated { get; set; }
        public int AvailabilityStatus { get; set; }
        public int BrandId { get; set; }

        public virtual Brands Brand { get; set; }
        public virtual ICollection<Reviews> Reviews { get; set; }
    }
}
