using StudentTeacherQnA.Entities;


namespace StudentTeacherQnA.Interface
{
    public interface IAnswerRepository
    {
        public void CreateAnswer(Answer answer);
        public void UpdateAnswer(Answer answer);
        public void DeleteAnswer(int id);
        public Task<Answer> GetAnswerById(int id);
        public Task<List<Answer>> GetAnswerByQuestionId(int QuestionId);
    }
}
