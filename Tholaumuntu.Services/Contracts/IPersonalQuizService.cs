using System.Collections.Generic;
using Tholaumuntu.DataAcces.Domain;

namespace Tholaumuntu.Services.Contracts
{
    public interface IPersonalQuizService
    {
        int Add(PersonalQuiz quiz);
        bool Update(PersonalQuiz quiz);
        IList<PersonalQuiz> AllQuizzes();
        PersonalQuiz GetQuizByUserId(int userId);
    }
}