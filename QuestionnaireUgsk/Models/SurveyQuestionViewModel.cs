using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionnaireUgsk.Models
{
    public class SurveyQuestionViewModel
    {
        public int SurveyQuestionID { get; set; }
        public int Position { get; set; }

        // опрос
        public int SurveyID { get; set; }
        // вопрос
        public QuestionViewModel Question { get; set; }
        // тип ответа
        public int AnswerCode { get; set; }
        // варианты ответов
        public List<AnswerChoiceViewModel> AnswerChoices { get; set; }
    }
}