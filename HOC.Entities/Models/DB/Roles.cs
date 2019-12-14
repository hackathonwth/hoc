using System;
using System.Collections.Generic;

namespace HOC.Entities.Models.DB
{
    public partial class Roles
    {
        public Roles()
        {
            UserRoles = new HashSet<UserRoles>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        public ICollection<UserRoles> UserRoles { get; set; }
    }
}
