using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Core.Models
{
    public class ReviewModel
    {
        public int Id { get; set; }
        public int? Rating { get; set; }
        public string Comment { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
    }
}
