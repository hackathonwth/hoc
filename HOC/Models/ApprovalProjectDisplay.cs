using HOC.Entities.Models;
using HOC.Entities.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HOC.Models
{
    public class ApprovalProjectDisplay
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ProjectStage Stage { get; set; }

        public ApprovalProjectDisplay(string name, string Description, DateTime startDate, DateTime endDate, ProjectStage status )
        {
            this.Name = name;
            this.Description = Description;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Stage = Stage;
        }
    }
}