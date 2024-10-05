namespace StudentTeacherQnA.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime AskedOn { get; set; }
        public int StudentId { get; set; }
        public Student AskedBy { get; set; }
    }
}
