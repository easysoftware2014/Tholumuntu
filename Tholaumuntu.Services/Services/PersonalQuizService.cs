using System.Collections.Generic;
using Tholaumuntu.DataAcces.Domain;
using Tholaumuntu.Repository.Repositories;
using Tholaumuntu.Services.Contracts;

namespace Tholaumuntu.Services.Services
{
    public class PersonalQuizService : IPersonalQuizService
    {
        private readonly PersonalQuizRepository _quizRepository;

        public PersonalQuizService()
        {
            _quizRepository = new PersonalQuizRepository();

        }
        public int Add(PersonalQuiz quiz)
        {
            return _quizRepository.Add(quiz);
        }

        public bool Update(PersonalQuiz quiz)
        {
            return _quizRepository.Update(quiz);
        }

        public IList<PersonalQuiz> AllQuizzes()
        {
            return _quizRepository.AllQuizzes();
        }
    }
}