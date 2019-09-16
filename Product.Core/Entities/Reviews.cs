using System;
using System.Collections.Generic;

namespace Product.Core.Entities
{
    public partial class Reviews
    {
        public int Id { get; set; }
        public int? Rating { get; set; }
        public string Comment { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }

        public virtual Products Product { get; set; }
        public virtual Users User { get; set; }
    }
}
