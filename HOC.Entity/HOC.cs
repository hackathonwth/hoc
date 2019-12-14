namespace HOC.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HOC : DbContext
    {
        public HOC()
            : base("name=HOCmodel")
        {
        }

        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectStatu> ProjectStatus { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ProjectAudit> ProjectAudits { get; set; }
        public virtual DbSet<Workflow> Workflows { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectStatu>()
                .HasMany(e => e.Projects)
                .WithRequired(e => e.ProjectStatu)
                .HasForeignKey(e => e.StatusID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.UserRoles)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Projects)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.CreatedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Projects1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.ModifiedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Projects2)
                .WithRequired(e => e.User2)
                .HasForeignKey(e => e.ApprovedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserRoles)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Workflow>()
                .Property(e => e.WorkflowName)
                .IsUnicode(false);
        }
    }
}
