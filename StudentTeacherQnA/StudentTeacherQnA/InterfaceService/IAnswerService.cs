using StudentTeacherQnA.Entities;

namespace StudentTeacherQnA.InterfaceService
{
    public interface IAnswerService
    {
        public void CreateAnswer(Answer answer);
        public Task<List<Answer>> GetAnswerByQuestionId(int QuestionId);
    }
}
