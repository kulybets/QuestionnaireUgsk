using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.BLL.DTO
{
    public class SurveyDTO
    {
        public int SurveyID { get; set; }
        public string Name { get; set; }
        public bool IsDelete { get; set; }
        public List<SurveyQuestionDTO> SurveyQuestions { get; set; }
    }
}
