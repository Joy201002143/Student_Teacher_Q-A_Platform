namespace StudentTeacherQnA.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string Content { get; set; }
        public DateTime AnsweredOn { get; set; }
        public int TeacherId { get; set; }
        public Teacher AnsweredBy { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
