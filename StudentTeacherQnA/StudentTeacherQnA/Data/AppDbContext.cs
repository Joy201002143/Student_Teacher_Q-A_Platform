using Microsoft.EntityFrameworkCore;
using StudentTeacherQnA.Models;
using System;

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
            // Disable cascading deletes for User relationships
            modelBuilder.Entity<Question>()
                .HasOne(q => q.AskedBy)
                .WithMany(u => u.Questions)
                .HasForeignKey(q => q.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Answer>()
                .HasOne(a => a.RepliedBy)
                .WithMany(u => u.Answers)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Enable cascade delete between Question and Answer
            modelBuilder.Entity<Answer>()
                .HasOne(a => a.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(a => a.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed moderator and student users
            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 1,
                Name = "Admin",
                Email = "admin@qna.com",
                Password = "admin123",
                Role = "Moderator"
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 2,
                Name = "Student One",
                Email = "student1@qna.com",
                Password = "student123",
                Role = "Student"
            });

            // Seed sample questions
            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    QuestionId = 1,
                    Title = "What is Object-Oriented Programming?",
                    Content = "Can someone explain the concept of OOP with examples?",
                    CreatedAt = DateTime.Now.AddDays(-5),
                    UserId = 2 // Posted by Student One
                },
                new Question
                {
                    QuestionId = 2,
                    Title = "How does ASP.NET Core handle middleware?",
                    Content = "What is middleware in ASP.NET Core and how does the request pipeline work?",
                    CreatedAt = DateTime.Now.AddDays(-3),
                    UserId = 2 // Posted by Student One
                }
            );

            // Seed answers for the sample questions
            modelBuilder.Entity<Answer>().HasData(
                new Answer
                {
                    AnswerId = 1,
                    Content = "OOP is a programming paradigm based on the concept of objects...",
                    CreatedAt = DateTime.Now.AddDays(-4),
                    UserId = 1, // Answered by Admin
                    QuestionId = 1
                },
                new Answer
                {
                    AnswerId = 2,
                    Content = "Middleware in ASP.NET Core is a component that processes requests...",
                    CreatedAt = DateTime.Now.AddDays(-2),
                    UserId = 1, // Answered by Admin
                    QuestionId = 2
                }
            );
        }
    }
}
