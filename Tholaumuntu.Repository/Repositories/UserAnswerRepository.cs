using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Tholaumuntu.DataAcces.Contexts;
using Tholaumuntu.DataAcces.Domain;
using Tholaumuntu.Repository.Contracts;

namespace Tholaumuntu.Repository.Repositories
{
    public class UserAnswerRepository : IUserAnswerRepository
    {
        private TholaUmuntuContext _tholaUmuntuContext;

        public UserAnswerRepository()
        {
            _tholaUmuntuContext = new TholaUmuntuContext();
        }
        public int Add(List<UserAnswer> userAnswer)
        {
            try
            {
                using (_tholaUmuntuContext = new TholaUmuntuContext())
                {
                    _tholaUmuntuContext.UserAnswers.AddRange(userAnswer);
                    return _tholaUmuntuContext.SaveChanges();
                }
            }
            catch (DbException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public IList<UserAnswer> List(int userId)
        {
            return _tholaUmuntuContext.UserAnswers.ToList();
        }

        public UserAnswer GetAnswerByQuestionId(int questionId)
        {
            try
            {
                using (_tholaUmuntuContext = new TholaUmuntuContext())
                {
                    return _tholaUmuntuContext.UserAnswers.Single(x => x.QuestionId == questionId);
                }
            }
            catch (DbException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void RemoveAll(List<UserAnswer> answers)
        {
            try
            {
                using (_tholaUmuntuContext)
                {
                    _tholaUmuntuContext.UserAnswers.RemoveRange(answers);
                    _tholaUmuntuContext.SaveChanges();
                }
            }
            catch (DbException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}