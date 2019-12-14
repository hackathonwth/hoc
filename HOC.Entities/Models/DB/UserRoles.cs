using System;
using System.Collections.Generic;

namespace HOC.Entities.Models.DB
{
    public partial class UserRoles
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public bool Active { get; set; }

        public Roles Role { get; set; }
        public Users User { get; set; }
    }
}
