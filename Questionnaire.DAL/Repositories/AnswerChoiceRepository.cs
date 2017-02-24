using Questionnaire.DAL.EF;
using Questionnaire.DAL.Entities;
using Questionnaire.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Questionnaire.DAL.Repositories
{
    public class AnswerChoiceRepository : IRepository<AnswerChoice>
    {
        private QuestionnaireContext ctx;

        public AnswerChoiceRepository(QuestionnaireContext context)
        {
            this.ctx = context;
        }

        public IEnumerable<AnswerChoice> GetAll()
        {
            return ctx.AnswerChoices;
        }

        public AnswerChoice Get(int id)
        {
            return ctx.AnswerChoices.Find(id);
        }

        public void Create(AnswerChoice item)
        {
            ctx.AnswerChoices.Add(item);
        }

        public void Update(AnswerChoice item)
        {
            ctx.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<AnswerChoice> Find(Func<AnswerChoice, Boolean> predicate)
        {
            return ctx.AnswerChoices.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            AnswerChoice item = ctx.AnswerChoices.Find(id);
            if (item != null)
                ctx.AnswerChoices.Remove(item);
        }
    }
}
