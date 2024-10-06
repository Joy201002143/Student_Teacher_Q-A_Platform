using System;
using System.ComponentModel.DataAnnotations;

namespace StudentTeacherQnA.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }  // Foreign key to User
        public User RepliedBy { get; set; }

        public int QuestionId { get; set; }  // Foreign key to Question
        public Question Question { get; set; }
    }
}
