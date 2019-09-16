using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductUI.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public int UserType { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
