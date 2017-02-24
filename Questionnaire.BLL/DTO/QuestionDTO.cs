using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.BLL.DTO
{
    public class QuestionDTO
    {
        public int QuestionID { get; set; }
        public string QuestionText { get; set; }
        public bool IsDelete { get; set; }
    }
}
