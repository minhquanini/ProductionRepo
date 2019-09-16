using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductUI.Models
{
    public class ReviewViewModel
    {
        public int Id { get; set; }
        [Required]
        public int? Rating { get; set; }
        [Required]
        public string Comment { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }

        
    }

    
}
