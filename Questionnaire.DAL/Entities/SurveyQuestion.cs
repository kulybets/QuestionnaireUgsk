using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.DAL.Entities
{
    public class SurveyQuestion
    {
        public int SurveyQuestionID { get; set; }
        public int Position { get; set; }

        // опрос
        public Survey Survey { get; set; }
        // вопрос
        public Question Question { get; set; }
        // тип ответа
        public AnswerType AnswerType { get; set; }
        // варианты ответов
        public List<AnswerChoice> AnswerChoices { get; set; }
    }
}
