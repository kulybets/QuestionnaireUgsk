using System;
using Questionnaire.BLL.DTO;
using Questionnaire.BLL.Interfaces;
using Questionnaire.DAL.Interfaces;
using Questionnaire.DAL.Entities;
using System.Collections.Generic;
using AutoMapper;
using Questionnaire.BLL.Infrastructure;
using System.Linq;

namespace Questionnaire.BLL.Services
{
    public class SurveyService : ISurveyService
    {
        IUnitOfWork Database { get; set; }

        public SurveyService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<SurveyDTO> GetAll()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Survey, SurveyDTO>());
            return Mapper.Map<IEnumerable<Survey>, List<SurveyDTO>>(Database.Surveys.GetAll());
        }

        public IEnumerable<SurveyQuestionDTO> GetSurveyQuestions(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не задан id опроса","");
            }
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Question, QuestionDTO>();
                    cfg.CreateMap<AnswerChoice, AnswerChoiceDTO>();
                    cfg.CreateMap<SurveyQuestion, SurveyQuestionDTO>()
                        .ForMember("AnswerCode", opt => opt.MapFrom(src => src.AnswerType.Code))
                        .ForMember("SurveyID", opt => opt.MapFrom(src => src.Survey.SurveyID));
                });
                        
            return config.CreateMapper().Map<IEnumerable<SurveyQuestion>, List<SurveyQuestionDTO>>(Database.SurveyQuestions.Find(sq => sq.Survey.SurveyID == id));
        }

        public SurveyDTO GetWithQuestions(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не задан id опроса", "");
            }
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Survey, SurveyDTO>();
                    cfg.CreateMap<Question, QuestionDTO>();
                    cfg.CreateMap<AnswerChoice, AnswerChoiceDTO>();
                    cfg.CreateMap<SurveyQuestion, SurveyQuestionDTO>()
                        .ForMember("AnswerCode", opt => opt.MapFrom(src => src.AnswerType.Code))
                        .ForMember("SurveyID", opt => opt.MapFrom(src => src.Survey.SurveyID));
                });

            return config.CreateMapper().Map<Survey, SurveyDTO>(Database.Surveys.GetWithQuestions(id.Value));
        }

        public void SaveAnswer(AnswerDTO answerDto)
        {
            Answer answer = new Answer
            {
                AnswerText = answerDto.AnswerText,
                Question = Database.Questions.Get(answerDto.QuestionID),
                Survey = Database.Surveys.Get(answerDto.SurveyID)
            };
            if (answerDto.AnswerChoiceID > 0)
            {
                answer.AnswerChoice = Database.AnswerChoices.Get(answerDto.AnswerChoiceID);
            }
            Database.Answers.Create(answer);
            Database.Save();
        }
    }
}
