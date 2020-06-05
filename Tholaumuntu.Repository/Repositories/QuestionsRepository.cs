using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Tholaumuntu.DataAcces.Contexts;
using Tholaumuntu.DataAcces.Domain;
using Tholaumuntu.Repository.Contracts;

namespace Tholaumuntu.Repository.Repositories
{
    public class QuestionsRepository : IQuestionRepository
    {
        private readonly TholaUmuntuContext _tholaUmuntuContext;

        public QuestionsRepository()
        {
          _tholaUmuntuContext = new TholaUmuntuContext();   
        }
        public int AddQuestion(Question question)
        {
            try
            {
                using (_tholaUmuntuContext)
                {
                    _tholaUmuntuContext.Questions.Add(question);
                    return _tholaUmuntuContext.SaveChanges();
                }

            }
            catch (DbException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public IList<Question> GetAllQuestions()
        {
            try
            {
                using (_tholaUmuntuContext)
                {
                    return _tholaUmuntuContext.Questions.ToList();
                }
            }
            catch (DbException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}