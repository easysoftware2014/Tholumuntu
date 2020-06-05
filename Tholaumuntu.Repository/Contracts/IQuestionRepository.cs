using System.Collections;
using System.Collections.Generic;
using Tholaumuntu.DataAcces.Domain;

namespace Tholaumuntu.Repository.Contracts
{
    public interface IQuestionRepository
    {
        int AddQuestion(Question question);
        IList<Question> GetAllQuestions();
    }
}