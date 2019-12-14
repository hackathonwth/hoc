namespace HOC.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Project
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "text")]
        [Required]
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

        public int StatusID { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }

        public virtual ProjectStatu ProjectStatu { get; set; }

        public virtual User User2 { get; set; }
    }
}
