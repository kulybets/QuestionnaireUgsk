using Questionnaire.DAL.EF;
using Questionnaire.DAL.Entities;
using Questionnaire.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Questionnaire.DAL.Repositories
{
    public class AnswerTypeRepository : IRepository<AnswerType>
    {
        private QuestionnaireContext ctx;

        public AnswerTypeRepository(QuestionnaireContext context)
        {
            this.ctx = context;
        }

        public IEnumerable<AnswerType> GetAll()
        {
            return ctx.AnswerTypes;
        }

        public AnswerType Get(int id)
        {
            return ctx.AnswerTypes.Find(id);
        }

        public void Create(AnswerType item)
        {
            ctx.AnswerTypes.Add(item);
        }

        public void Update(AnswerType item)
        {
            ctx.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<AnswerType> Find(Func<AnswerType, Boolean> predicate)
        {
            return ctx.AnswerTypes.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            AnswerType item = ctx.AnswerTypes.Find(id);
            if (item != null)
                ctx.AnswerTypes.Remove(item);
        }
    }
}
