using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Tholaumuntu.DataAcces.Domain;
using Tholaumuntu.Repository.Repositories;
using Tholaumuntu.Services.Contracts;

namespace Tholaumuntu.Services.Services
{
    public class UserAnswerService : IUserAnswerService
    {
        private readonly UserAnswerRepository _answerRepository;
        public UserAnswerService()
        {
            _answerRepository = new UserAnswerRepository();
        }

        public int Add(List<UserAnswer> userAnswer)
        {
            return _answerRepository.Add(userAnswer);
        }

        public IList<UserAnswer> List(int userId)
        {
            return _answerRepository.List(userId).ToList();
        }

        public UserAnswer GetAnswerByQuestionId(int questionId)
        {
            return _answerRepository.GetAnswerByQuestionId(questionId);
        }

        public void RemoveAll(List<UserAnswer> answers)
        {
            _answerRepository.RemoveAll(answers);
        }
    }
}