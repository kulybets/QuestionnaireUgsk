using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.DAL.Entities
{
    public class Survey
    {
        public int SurveyID { get; set; }
        public string Name { get; set; }
        public bool IsDelete { get; set; }

        // опрос-вопросы
        public List<SurveyQuestion> SurveyQuestions { get; set; }
    }
}
