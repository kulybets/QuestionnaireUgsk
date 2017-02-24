using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace QuestionnaireUgsk.Models
{
    public class QuestionViewModel
    {
        public int QuestionID { get; set; }
        public int SurveyID { get; set; }
        public string QuestionText { get; set; }
        public int Position { get; set; }
        public int AnswerCode { get; set; }
        public int SelectedAnswerChoiceID { get; set; }
        public string TextAnswer { get; set; }
        public List<AnswerChoiceViewModel> AnswerChoices { get; set; }
        public string QuestionTextWithNumber {
            get
            {
                return String.Format("Вопрос {0}. {1}", Position, QuestionText);
            }
        }
    }
}