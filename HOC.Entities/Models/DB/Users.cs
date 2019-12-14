using System;
using System.Collections.Generic;

namespace HOC.Entities.Models.DB
{
    public partial class Users
    {
        public Users()
        {
            ProjectsApprovedByNavigation = new HashSet<Projects>();
            ProjectsCreatedByNavigation = new HashSet<Projects>();
            ProjectsModifiedByNavigation = new HashSet<Projects>();
            UserRoles = new HashSet<UserRoles>();
        }

        public int Uid { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialty { get; set; }
        public string Organizations { get; set; }

        public ICollection<Projects> ProjectsApprovedByNavigation { get; set; }
        public ICollection<Projects> ProjectsCreatedByNavigation { get; set; }
        public ICollection<Projects> ProjectsModifiedByNavigation { get; set; }
        public ICollection<UserRoles> UserRoles { get; set; }
    }
}
