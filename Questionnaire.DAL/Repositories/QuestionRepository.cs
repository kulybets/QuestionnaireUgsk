using Questionnaire.DAL.EF;
using Questionnaire.DAL.Entities;
using Questionnaire.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Questionnaire.DAL.Repositories
{
    public class QuestionRepository : IRepository<Question>
    {
        private QuestionnaireContext ctx;

        public QuestionRepository(QuestionnaireContext context)
        {
            this.ctx = context;
        }

        public IEnumerable<Question> GetAll()
        {
            return ctx.Questions;
        }

        public Question Get(int id)
        {
            return ctx.Questions.Find(id);
        }

        public void Create(Question item)
        {
            ctx.Questions.Add(item);
        }

        public void Update(Question item)
        {
            ctx.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<Question> Find(Func<Question, Boolean> predicate)
        {
            return ctx.Questions.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Question item = ctx.Questions.Find(id);
            if (item != null)
                ctx.Questions.Remove(item);
        }
    }
}
