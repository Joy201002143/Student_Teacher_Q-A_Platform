using StudentTeacherQnA.Entities;
using StudentTeacherQnA.Interface;
using StudentTeacherQnA.InterfaceService;

namespace StudentTeacherQnA.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;
        public AnswerService(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public void CreateAnswer(Answer answer)
        {
            _answerRepository.CreateAnswer(answer);
        }

        public async Task<List<Answer>> GetAnswerByQuestionId(int QuestionId)
        {
            var answer = await _answerRepository.GetAnswerByQuestionId(QuestionId);
            return answer;
        }
    }
}
