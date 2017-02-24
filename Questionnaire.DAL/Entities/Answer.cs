using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.DAL.Entities
{
    public class Answer
    {
        public int AnswerID { get; set; }
        public string AnswerText { get; set; }
        //public int MyProperty { get; set; }

        public Survey Survey { get; set; }
        public Question Question { get; set; }
        public AnswerChoice AnswerChoice { get; set; }
    }
}
