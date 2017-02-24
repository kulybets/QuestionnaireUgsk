using Questionnaire.DAL.EF;
using Questionnaire.DAL.Entities;
using Questionnaire.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Questionnaire.DAL.Repositories
{
    public class SurveyQuestionRepository : IRepository<SurveyQuestion>
    {
        private QuestionnaireContext ctx;

        public SurveyQuestionRepository(QuestionnaireContext context)
        {
            this.ctx = context;
        }

        public IEnumerable<SurveyQuestion> GetAll()
        {
            return ctx.SurveyQuestions.Include(sq => sq.Survey).Include(sq => sq.Question).Include(sq => sq.AnswerChoices);
        }

        public SurveyQuestion Get(int id)
        {
            return ctx.SurveyQuestions.Find(id);
        }

        public void Create(SurveyQuestion item)
        {
            ctx.SurveyQuestions.Add(item);
        }

        public void Update(SurveyQuestion item)
        {
            ctx.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<SurveyQuestion> Find(Func<SurveyQuestion, Boolean> predicate)
        {
            return ctx.SurveyQuestions.Include(sq => sq.Survey).Include(sq => sq.AnswerType).Include(sq => sq.Question).Include(sq => sq.AnswerChoices).Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            SurveyQuestion item = ctx.SurveyQuestions.Find(id);
            if (item != null)
                ctx.SurveyQuestions.Remove(item);
        }
    }
}
