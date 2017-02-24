using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.BLL.DTO
{
    public class SurveyQuestionDTO
    {
        public int SurveyQuestionID { get; set; }
        public int Position { get; set; }
        public int SurveyID { get; set; }
        public int AnswerCode { get; set; }
        public QuestionDTO Question { get; set; }
        public List<AnswerChoiceDTO> AnswerChoices { get; set; }
    }
}
