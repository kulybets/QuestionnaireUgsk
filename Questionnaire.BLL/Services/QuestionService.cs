using System;
using Questionnaire.BLL.DTO;
using Questionnaire.BLL.Interfaces;
using Questionnaire.DAL.Interfaces;
using Questionnaire.DAL.Entities;
using System.Collections.Generic;
using AutoMapper;

namespace Questionnaire.BLL.Services
{
    public class QuestionService : IQuestionService
    {
        IUnitOfWork Database { get; set; }

        public QuestionService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public void SaveQuestion(QuestionDTO questionDto)
        {
            Question question = new Question
            {
                IsDelete = false,
                QuestionText = questionDto.QuestionText
            };
            Database.Questions.Create(question);
            Database.Save();
        }

        public IEnumerable<QuestionDTO> GetAll()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Question, QuestionDTO>());
            return Mapper.Map<IEnumerable<Question>, List<QuestionDTO>>(Database.Questions.GetAll());
        }
    }
}
