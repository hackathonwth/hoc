using System;
using System.Collections.Generic;

namespace HOC.Entities.Models.DB
{
    public partial class Projects
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Approved { get; set; }
        public DateTime ApprovedOn { get; set; }
        public int ApprovedBy { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
        public int StatusId { get; set; }

        public Users ApprovedByNavigation { get; set; }
        public Users CreatedByNavigation { get; set; }
        public Users ModifiedByNavigation { get; set; }
        public ProjectStatus Status { get; set; }
    }
}
