using AutoMapper;
using Questionnaire.BLL.DTO;
using Questionnaire.BLL.Infrastructure;
using Questionnaire.BLL.Interfaces;
using QuestionnaireUgsk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuestionnaireUgsk.Controllers
{
    public class SurveyController : Controller
    {
        ISurveyService surveyService;

        public SurveyController(ISurveyService serv)
        {
            surveyService = serv;
        }

        // GET: Survey
        public ActionResult Index()
        {
            IEnumerable<SurveyDTO> surveyDtos = surveyService.GetAll();
            Mapper.Initialize(cfg => cfg.CreateMap<SurveyDTO, SurveyViewModel>());
            var surveys = Mapper.Map<IEnumerable<SurveyDTO>, List<SurveyViewModel>>(surveyDtos);
            return View(surveys);
        }

        // GET: Survey/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Survey/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult QuestionnaireResult()
        {
            SurveyViewModel svm = new SurveyViewModel();
            if (TempData["svm"] != null)
            {
                svm = (SurveyViewModel)TempData["svm"];
                return View(svm);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Questionnaire(int? id)
        {
            try
            {
                var rr = surveyService.GetWithQuestions(id);

                var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<AnswerChoiceDTO, AnswerChoiceViewModel>();
                    cfg.CreateMap<SurveyQuestionDTO, QuestionViewModel>()
                        .ForMember("QuestionID", opt => opt.MapFrom(src => src.Question.QuestionID))
                        .ForMember("QuestionText", opt => opt.MapFrom(src => src.Question.QuestionText));
                    cfg.CreateMap<SurveyDTO, SurveyViewModel>()
                        .ForMember("Questions", opt => opt.MapFrom(src => src.SurveyQuestions));
                });

                var r = config.CreateMapper().Map<SurveyDTO, SurveyViewModel>(rr);

                return View(r);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Questionnaire(SurveyViewModel svm)
        {
            foreach (var q in svm.Questions)
            {                
                switch (q.AnswerCode)
                {
                    case 1:
                        //Checkbox
                        foreach (var ac in q.AnswerChoices.Where(x => x.IsSelected))
                        {
                            AnswerDTO answer1 = new AnswerDTO();
                            answer1.SurveyID = svm.SurveyID;
                            answer1.QuestionID = q.QuestionID;
                            answer1.AnswerChoiceID = ac.AnswerChoiceID;
                            surveyService.SaveAnswer(answer1);
                        }

                        break;
                    case 2:
                        //Select
                        AnswerDTO answer2 = new AnswerDTO();
                        answer2.SurveyID = svm.SurveyID;
                        answer2.QuestionID = q.QuestionID;
                        answer2.AnswerChoiceID = q.SelectedAnswerChoiceID;
                        surveyService.SaveAnswer(answer2);
                        break;
                    case 3:
                        //Text
                        AnswerDTO answer3 = new AnswerDTO();
                        answer3.SurveyID = svm.SurveyID;
                        answer3.QuestionID = q.QuestionID;
                        answer3.AnswerText = q.TextAnswer;
                        surveyService.SaveAnswer(answer3);
                        break;
                    default:
                        break;
                }
                TempData["svm"] = svm;
            }
            return RedirectToAction("QuestionnaireResult");
        }

        public ActionResult GetSurveyQuestions(int? id)
        {
            try
            {
                var rr = surveyService.GetSurveyQuestions(id);

                var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<QuestionDTO, QuestionViewModel>();
                    cfg.CreateMap<AnswerChoiceDTO, AnswerChoiceViewModel>();
                    cfg.CreateMap<SurveyQuestionDTO, SurveyQuestionViewModel>();
                });

                var r = config.CreateMapper().Map<IEnumerable<SurveyQuestionDTO>, List<SurveyQuestionViewModel>>(rr);

                return View(r);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        // POST: Survey/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Survey/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Survey/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Survey/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Survey/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
