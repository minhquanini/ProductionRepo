using System;
using System.Collections.Generic;

namespace Product.Core.Entities
{
    public partial class Users
    {
        public Users()
        {
            Reviews = new HashSet<Reviews>();
        }

        public int Id { get; set; }
        public int UserType { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public virtual ICollection<Reviews> Reviews { get; set; }
    }
}
