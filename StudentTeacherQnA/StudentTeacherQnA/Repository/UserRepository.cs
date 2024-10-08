﻿using Microsoft.EntityFrameworkCore;
using StudentTeacherQnA.Entities;
using StudentTeacherQnA.Interface;

namespace StudentTeacherQnA.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<ApplicationUser> _users;
        private readonly DbSet<Question> _questions;
        private readonly DbSet<Answer> _answers;

        public UserRepository(AppDbContext context)
        {
            _context = context;
            _users = _context.Set<ApplicationUser>();
            _questions = _context.Set<Question>();
            _answers = _context.Set<Answer>();
        }

        public async Task<List<(string, string, string)>> GetRespondedQA(string UserID)
        {

            var answers = await _context.Answers
                .Where(s => s.UserId.ToString().ToLower() == UserID.ToLower())
                .ToListAsync();

            List<(string, string, string)> respondedQA = new List<(string, string, string)>();

            if (answers != null)
            {
                foreach (var answersItem in answers)
                {
                    string questionContent = _questions.Where(q => q.Id == answersItem.QuestionId).Select(q => q.Content).FirstOrDefault();
                    string questioner = _questions.Where(q => q.Id == answersItem.QuestionId).Select(q => q.UserId).FirstOrDefault();

                    answersItem.UserId = GetUserName(questioner);

                    respondedQA.Add((answersItem.UserId, questionContent, answersItem.Content));
                }
            }
            return respondedQA;
        }

        public string? GetUserName(string UserID)
        {
            string? name = _users.Where(u => u.Id == UserID).Select(u => u.UserName).FirstOrDefault();
            return name;
        }
    }
}
