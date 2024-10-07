namespace StudentTeacherQnA.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int QuestionId { get; set; }
        public string UserId { get; set; } // Identify by the user ID who asked questions

    }
}
