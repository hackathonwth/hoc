using System;
using System.Collections.Generic;

namespace HOC.Entities.Models.DB
{
    public partial class ProjectStatus
    {
        //public ProjectStatus()
        //{
        //    Projects = new HashSet<Projects>();
        //}

        public int Id { get; set; }
        public ProjectStage Stage { get; set; }
        public bool? Active { get; set; }

        public virtual Projects Projects { get; set; }
    }
}
