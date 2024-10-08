using StudentTeacherQnA.Entities;

namespace StudentTeacherQnA.InterfaceService
{
    public interface IQuestionService
    {
        public void CreateQuestion(Question question);
        public Task DeleteQuestionByQuestionID(int QuestionId);
        public Task<IEnumerable<Question>?> GetAllQuestionsByUserID(string UserID);
        public Task<IEnumerable<Question>> GetAllQuestions();
        public Task<Question> GetQuestionById(int id);
    }
}
