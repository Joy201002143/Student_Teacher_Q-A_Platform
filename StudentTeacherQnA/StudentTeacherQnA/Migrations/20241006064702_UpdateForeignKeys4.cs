using Microsoft.EntityFrameworkCore;
using StudentTeacherQnA.Models;

namespace StudentTeacherQnA.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Completely remove foreign key constraints to avoid the error

            // User - Question: One-to-Many (No Constraint)
            modelBuilder.Entity<Question>()
                .HasOne(q => q.AskedBy)
                .WithMany(u => u.Questions)
                .HasForeignKey(q => q.UserId)
                .OnDelete(DeleteBehavior.NoAction);  // No action on delete

            // User - Answer: One-to-Many (No Constraint)
            modelBuilder.Entity<Answer>()
                .HasOne(a => a.RepliedBy)
                .WithMany(u => u.Answers)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.NoAction);  // No action on delete

            // Question - Answer: One-to-Many (No Constraint)
            modelBuilder.Entity<Answer>()
                .HasOne(a => a.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(a => a.QuestionId)
                .OnDelete(DeleteBehavior.NoAction);  // No action on delete

            // Remove foreign key constraints by manually disabling indexes
            modelBuilder.Entity<Question>()
                .Ignore(q => q.AskedBy);

            modelBuilder.Entity<Answer>()
                .Ignore(a => a.RepliedBy)
                .Ignore(a => a.Question);
        }
    }
}
