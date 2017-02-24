using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionnaireUgsk.Models
{
    public class AnswerChoiceViewModel
    {
        public int AnswerChoiceID { get; set; }
        public int Position { get; set; }
        public string Text { get; set; }
        public bool IsSelected { get; set; }
    }
}