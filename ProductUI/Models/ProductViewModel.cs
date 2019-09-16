using Product.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Product.Core.Enums.Enums;

namespace ProductUI.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public DateTime DateCreated { get; set; }
        public int AvailabilityStatus { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string UserName { get; set; }
        public string Comment { get; set; }
        public int? Rating { get; set; }

        public string DisplayAvailabilityStatus
        {
            get
            {
                return ((AvailabilityStatus)AvailabilityStatus).ToDisplayName();
            }
        }
    }
}
