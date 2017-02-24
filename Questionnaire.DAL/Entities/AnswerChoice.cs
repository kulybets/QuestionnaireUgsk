using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.DAL.Entities
{
    public class AnswerChoice
    {
        public int AnswerChoiceID { get; set; }
        public int Position { get; set; }
        public string Text { get; set; }

        // опрос-вопрос
        public SurveyQuestion SurveyQuestion { get; set; }
    }
}
