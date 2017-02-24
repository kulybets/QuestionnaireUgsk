using Questionnaire.DAL.EF;
using Questionnaire.DAL.Entities;
using Questionnaire.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Questionnaire.DAL.Repositories
{
    public class AnswerRepository : IRepository<Answer>
    {
        private QuestionnaireContext ctx;

        public AnswerRepository(QuestionnaireContext context)
        {
            this.ctx = context;
        }

        public IEnumerable<Answer> GetAll()
        {
            return ctx.Answers;
        }

        public Answer Get(int id)
        {
            return ctx.Answers.Find(id);
        }

        public void Create(Answer item)
        {
            ctx.Answers.Add(item);
        }

        public void Update(Answer item)
        {
            ctx.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<Answer> Find(Func<Answer, Boolean> predicate)
        {
            return ctx.Answers.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Answer item = ctx.Answers.Find(id);
            if (item != null)
                ctx.Answers.Remove(item);
        }
    }
}
