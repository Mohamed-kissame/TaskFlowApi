using Microsoft.EntityFrameworkCore;
using TaskFlow.Models;


namespace TaskFlow.DataAccess
{
    public class TaskFlowDbContext : DbContext
    {
        public TaskFlowDbContext(DbContextOptions<TaskFlowDbContext> options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<UserRole> UserRoles { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<Project> Projects { get; set; }

        public virtual DbSet<ProjectTask> ProjectTasks { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasIndex(e => e.Email)
                    .IsUnique();

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.IsActive)
                    .HasDefaultValue(true);

                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("SYSUTCDATETIME()");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {

                entity.HasKey(e => new { e.UserID, e.RoleID });

                entity.HasOne(ur => ur.User)
                   .WithMany(u => u.UserRoles)
                   .HasForeignKey(ur => ur.UserID)
                   .OnDelete(DeleteBehavior.NoAction);


                entity.HasOne(ur => ur.Role)
                     .WithMany(r => r.UserRoles)
                     .HasForeignKey(ur => ur.RoleID)
                     .OnDelete(DeleteBehavior.NoAction);


            });

            modelBuilder.Entity<Role>(entity =>
            {
               entity.HasKey(e => e.RoleID); 
               entity.HasIndex(e => e.RoleName)
                    .IsUnique();
                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50);


            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.ProjectID);
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Description)
                    .HasMaxLength(500);

                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("SYSUTCDATETIME()");

                entity.Property(e => e.IsArchived).HasDefaultValue(false);

                entity.HasOne(p => p.Owner)
                    .WithMany(u => u.OwnedProjects).HasForeignKey(p => p.OwnerUserID).OnDelete(DeleteBehavior.NoAction);

            });

            modelBuilder.Entity<ProjectTask>(entity =>
            {

                entity.HasKey(e => e.TaskID);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.Status).IsRequired().HasDefaultValue("TODO").HasMaxLength(30);
                entity.Property(e => e.Priority).IsRequired().HasDefaultValue("Medium").HasMaxLength(20);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("SYSUTCDATETIME()");
                entity.Property(e => e.UpdatedAt).HasColumnType("datetime2");
                entity.Property(e => e.DueDate).HasColumnType("datetime2");

                entity.HasOne(t => t.Project).WithMany(p => p.Tasks).HasForeignKey(t => t.ProjectID)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(t => t.CreatedByUser).WithMany(u => u.CreatedTasks).HasForeignKey(t => t.CreatedByUserID)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(t => t.AssignedToUser).WithMany(u => u.AssignedTasks).HasForeignKey(t => t.AssignedToUserID)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.CommentID);
                entity.Property(e => e.Content).IsRequired().HasMaxLength(1000);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("SYSUTCDATETIME()");

                entity.HasOne(c => c.Task).WithMany(t => t.Comments).HasForeignKey(c => c.TaskID)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(c => c.User).WithMany(u => u.Comments).HasForeignKey(c => c.UserID)
                    .OnDelete(DeleteBehavior.NoAction);
            });



            base.OnModelCreating(modelBuilder);
        }


       
    }
}