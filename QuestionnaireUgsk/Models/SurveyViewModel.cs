using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionnaireUgsk.Models
{
    public class SurveyViewModel
    {
        public int SurveyID { get; set; }
        public string Name { get; set; }
        public List<QuestionViewModel> Questions { get; set; }
    }
}