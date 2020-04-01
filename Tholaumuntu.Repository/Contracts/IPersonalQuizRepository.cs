using System.Collections.Generic;
using Tholaumuntu.DataAcces.Domain;

namespace Tholaumuntu.Repository.Contracts
{
    public interface IPersonalQuizRepository
    {
        int Add(PersonalQuiz quiz);
        bool Update(PersonalQuiz quiz);
        IList<PersonalQuiz> AllQuizzes();
    }
}