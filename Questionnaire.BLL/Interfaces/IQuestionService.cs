using Questionnaire.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.BLL.Interfaces
{
    public interface IQuestionService
    {
        void SaveQuestion(QuestionDTO questionDto);
        IEnumerable<QuestionDTO> GetAll();
        void Dispose();
    }
}
