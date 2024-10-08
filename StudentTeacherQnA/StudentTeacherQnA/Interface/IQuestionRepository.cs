using StudentTeacherQnA.Entities;

namespace StudentTeacherQnA.Interface
{
    public interface IQuestionRepository
    {
        public void CreateQuestion(Question question);
        public Task DeleteQuestionByQuestionIDAsync(int QuestionId);
        public Task<IEnumerable<Question>?> GetAllQuestionsByUserID(string UserID);
        public Task<IEnumerable<Question>> GetAllQuestions();
        public Task<Question> GetQuestionById(int id);
    }
}
