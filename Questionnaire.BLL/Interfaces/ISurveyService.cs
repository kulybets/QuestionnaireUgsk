using Questionnaire.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.BLL.Interfaces
{
    public interface ISurveyService
    {
        IEnumerable<SurveyDTO> GetAll();
        IEnumerable<SurveyQuestionDTO> GetSurveyQuestions(int? id);
        SurveyDTO GetWithQuestions(int? id);
        void SaveAnswer(AnswerDTO questionDto);
        void Dispose();
    }
}
