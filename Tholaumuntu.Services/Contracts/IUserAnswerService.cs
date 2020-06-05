using System.Collections.Generic;
using Tholaumuntu.DataAcces.Domain;

namespace Tholaumuntu.Services.Contracts
{
    public interface IUserAnswerService
    {
        int Add(List<UserAnswer> userAnswer);
        IList<UserAnswer> List(int userId);
        UserAnswer GetAnswerByQuestionId(int questionId);
        void RemoveAll(List<UserAnswer> answers);
    }
}