using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Core.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public int UserType { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
