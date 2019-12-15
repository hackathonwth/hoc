using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HOC.Entities.Models.DB
{
    public partial class Projects
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None), Key]
        public int Id { get; set; }

        [DisplayName("Project Name")]
        [Required(ErrorMessage = "Project Name is required.")]
        public string Name { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
        public bool? Approved { get; set; }
        public DateTime ApprovedOn { get; set; }
        public int ApprovedBy { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
        public ProjectStage Stage { get; set; }
        public int? WorkflowId { get; set; }
        public int? CurrentStepId { get; set; }
        public String History { get; set; }
        public Users ApprovedByNavigation { get; set; }
        public Users CreatedByNavigation { get; set; }
        public Users ModifiedByNavigation { get; set; }
    }
}
