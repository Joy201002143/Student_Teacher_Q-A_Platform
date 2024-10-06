using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentTeacherQnA.Models
{
    public class Question
    {
        public int QuestionId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }  // Foreign key to User
        public User AskedBy { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}
