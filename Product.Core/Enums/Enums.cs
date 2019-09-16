using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Product.Core.Enums
{
    public class Enums
    {
        public enum AvailabilityStatus
        {
            [Display(Name = "In Stock")]
            InStock = 1,
            [Display(Name = "Out Of Stock")]
            OutOfStock = 2,
            [Display(Name = "Archived")]
            Archived = 3
        }

        public enum UserType
        {
            Customer = 1,
            Merchant = 2,

        }
    }
}
