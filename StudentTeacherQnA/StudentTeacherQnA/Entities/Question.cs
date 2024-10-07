namespace StudentTeacherQnA.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Content { get; set; } //Store the question contetent
        public String UserId { get; set; }    // Idetify the user using user id who asked the quesions
        public bool IsAnswered { get; set; } //Stores the answer
    }
}
