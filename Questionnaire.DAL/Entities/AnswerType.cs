using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.DAL.Entities
{
    public class AnswerType
    {
        public int AnswerTypeID { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }

        // опрос-вопросы
        public List<SurveyQuestion> SurveyQuestions { get; set; }
    }
}
