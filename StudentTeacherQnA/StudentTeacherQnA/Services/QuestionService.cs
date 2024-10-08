﻿using StudentTeacherQnA.Entities;
using StudentTeacherQnA.Interface;
using StudentTeacherQnA.InterfaceService;

namespace StudentTeacherQnA.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public void CreateQuestion(Question question)
        {
            _questionRepository.CreateQuestion(question);
        }

        public async Task DeleteQuestionByQuestionID(int QuestionId)
        {
            await _questionRepository.DeleteQuestionByQuestionIDAsync(QuestionId);
        }

        public async Task<IEnumerable<Question>> GetAllQuestions()
        {
            var questions = await _questionRepository.GetAllQuestions();
            return questions;
        }

        public async Task<IEnumerable<Question>?> GetAllQuestionsByUserID(string UserID)
        {
            var questions = await _questionRepository.GetAllQuestionsByUserID(UserID);
            return questions;
        }

        public Task<Question> GetQuestionById(int id)
        {
            var question = _questionRepository.GetQuestionById(id);
            return question;
        }
    }
}
