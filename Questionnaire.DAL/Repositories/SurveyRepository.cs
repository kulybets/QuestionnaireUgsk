using Questionnaire.DAL.EF;
using Questionnaire.DAL.Entities;
using Questionnaire.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Questionnaire.DAL.Repositories
{
    public class SurveyRepository : ISurveyRepository
    {
        private QuestionnaireContext ctx;

        public SurveyRepository(QuestionnaireContext context)
        {
            this.ctx = context;
        }

        public IEnumerable<Survey> GetAll()
        {
            return ctx.Surveys;
        }

        public Survey Get(int id)
        {
            return ctx.Surveys.Find(id);
        }

        public void Create(Survey item)
        {
            ctx.Surveys.Add(item);
        }

        public void Update(Survey item)
        {
            ctx.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<Survey> Find(Func<Survey, Boolean> predicate)
        {
            return ctx.Surveys.Where(predicate).ToList();
        }

        public Survey GetWithQuestions(int id)
        {
            return ctx.Surveys.Include("SurveyQuestions.AnswerType").Include("SurveyQuestions.Question").Include("SurveyQuestions.AnswerChoices").Where(x => x.SurveyID == id).FirstOrDefault();
        }

        public void Delete(int id)
        {
            Survey item = ctx.Surveys.Find(id);
            if (item != null)
                ctx.Surveys.Remove(item);
        }
    }
}
