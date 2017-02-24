using Questionnaire.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.DAL.Interfaces
{
    public interface ISurveyRepository : IRepository<Survey>
    {
        Survey GetWithQuestions(int id);
    }
}
