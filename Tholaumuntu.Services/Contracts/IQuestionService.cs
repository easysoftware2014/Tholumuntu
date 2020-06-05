using System.Collections.Generic;
using Tholaumuntu.DataAcces.Domain;

namespace Tholaumuntu.Services.Contracts
{
    public interface IQuestionService
    {
        int AddQuestion(Question question);
        IList<Question> GetAllQuestions();
    }
}