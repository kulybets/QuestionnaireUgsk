using Questionnaire.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Answer> Answers { get; }
        IRepository<AnswerChoice> AnswerChoices { get; }
        IRepository<AnswerType> AnswerTypes { get; }
        IRepository<Question> Questions { get; }
        ISurveyRepository Surveys { get; }
        IRepository<SurveyQuestion> SurveyQuestions { get; }
        void Save();
    }
}
