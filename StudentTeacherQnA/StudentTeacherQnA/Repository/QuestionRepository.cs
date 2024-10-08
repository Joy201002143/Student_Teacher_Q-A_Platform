using Microsoft.EntityFrameworkCore;
using StudentTeacherQnA.Entities;
using StudentTeacherQnA.Interface;

namespace StudentTeacherQnA.Repository
{

    public class QuestionRepository : IQuestionRepository
    {
        private readonly AppDbContext _context;
        private DbSet<Question> _table;

        public QuestionRepository(AppDbContext context)
        {
            _context = context;
            _table = _context.Set<Question>();
        }

        public void CreateQuestion(Question question)
        {
            _table.Add(question);
            _context.SaveChanges();
        }

        public async Task DeleteQuestionByQuestionIDAsync(int questionId)
        {
            var questionToRemove = _context.Questions.FirstOrDefault(s => s.Id == questionId);

            if (questionToRemove != null)
            {
                _context.Questions.Remove(questionToRemove);

            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Question>> GetAllQuestions()
        {
            var questions = new List<Question>();
            var query = await _context.Questions.OrderByDescending(s => s.Id).ToListAsync();

            if (query.Any() == true)
            {
                foreach (var item in query)
                {
                    questions.Add(new Question()
                    {
                        Id = item.Id,
                        Content = item.Content,
                        UserId = item.UserId,
                        IsAnswered = item.IsAnswered
                    });
                }
            }

            return questions;
        }

        public async Task<IEnumerable<Question>?> GetAllQuestionsByUserID(string userId)
        {
            var questions = new List<Question>();
            var query = await _context.Questions.Where(s => s.UserId.ToString().ToLower() == userId.ToLower()).ToListAsync();
            if (query.Any() == true)
            {
                foreach (var item in query)
                {
                    questions.Add(new Question()
                    {
                        Id = item.Id,
                        Content = item.Content,
                        UserId = item.UserId,
                        IsAnswered = item.IsAnswered
                    });
                }
            }

            return questions;
        }

        public async Task<Question> GetQuestionById(int id)
        {
            Question questions = new Question();
            var query = await _context.Questions.FirstOrDefaultAsync(s => s.Id == id);

            if (query != null)
            {
                questions.Id = query.Id;
                questions.Content = query.Content;
                questions.UserId = query.UserId;
                questions.IsAnswered = query.IsAnswered;
            }
            return questions;
        }
    }
}
