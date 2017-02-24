using Questionnaire.DAL.EF;
using Questionnaire.DAL.Entities;
using Questionnaire.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private QuestionnaireContext ctx;
        private AnswerRepository answerRepository;
        private AnswerChoiceRepository answerChoiceRepository;
        private AnswerTypeRepository answerTypeRepository;
        private QuestionRepository questionRepository;
        private SurveyQuestionRepository surveyQuestionRepository;
        private SurveyRepository surveyRepository;

        public EFUnitOfWork(string connectionString)
        {
            ctx = new QuestionnaireContext(connectionString);
        }
        public IRepository<Answer> Answers
        {
            get
            {
                if (answerRepository == null)
                    answerRepository = new AnswerRepository(ctx);
                return answerRepository;
            }
        }

        public IRepository<AnswerChoice> AnswerChoices
        {
            get
            {
                if (answerChoiceRepository == null)
                    answerChoiceRepository = new AnswerChoiceRepository(ctx);
                return answerChoiceRepository;
            }
        }

        public IRepository<AnswerType> AnswerTypes
        {
            get
            {
                if (answerTypeRepository == null)
                    answerTypeRepository = new AnswerTypeRepository(ctx);
                return answerTypeRepository;
            }
        }

        public IRepository<Question> Questions
        {
            get
            {
                if (questionRepository == null)
                    questionRepository = new QuestionRepository(ctx);
                return questionRepository;
            }
        }

        public ISurveyRepository Surveys
        {
            get
            {
                if (surveyRepository == null)
                    surveyRepository = new SurveyRepository(ctx);
                return surveyRepository;
            }
        }

        public IRepository<SurveyQuestion> SurveyQuestions
        {
            get
            {
                if (surveyQuestionRepository == null)
                    surveyQuestionRepository = new SurveyQuestionRepository(ctx);
                return surveyQuestionRepository;
            }
        }

        public void Save()
        {
            ctx.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    ctx.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
