using System.Collections.Generic;
using System.Linq;
using Tholaumuntu.DataAcces.Domain;
using Tholaumuntu.Repository.Repositories;
using Tholaumuntu.Services.Contracts;

namespace Tholaumuntu.Services.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly QuestionsRepository _questionsRepository;
        public QuestionService()
        {
            _questionsRepository = new QuestionsRepository();
        }
        public int AddQuestion(Question question)
        {
            return _questionsRepository.AddQuestion(question);
        }

        public IList<Question> GetAllQuestions()
        {
            return _questionsRepository.GetAllQuestions().ToList();
        }
    }
}