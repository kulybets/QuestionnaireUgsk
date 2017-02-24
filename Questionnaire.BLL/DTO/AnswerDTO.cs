using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.BLL.DTO
{
    public class AnswerDTO
    {
        public int AnswerID { get; set; }
        public string AnswerText { get; set; }

        public int SurveyID { get; set; }
        public int QuestionID { get; set; }
        public int AnswerChoiceID { get; set; }
    }
}
