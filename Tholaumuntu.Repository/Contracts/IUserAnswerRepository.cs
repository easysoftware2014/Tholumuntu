﻿using System.Collections.Generic;
using Tholaumuntu.DataAcces.Domain;

namespace Tholaumuntu.Repository.Contracts
{
    public interface IUserAnswerRepository
    {
        int Add(List<UserAnswer> userAnswer);
        IList<UserAnswer> List(int userId);
        UserAnswer GetAnswerByQuestionId(int questionId);
        void RemoveAll(List<UserAnswer> answers);
    }
}