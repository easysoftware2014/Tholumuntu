using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tholaumuntu.DataAcces.Domain;
using Tholaumuntu.Repository.Contracts;
using Tholaumuntu.Repository.Repositories;
using Tholaumuntu.Services.Services;
using Tholumuntu.Helpers;
using Tholumuntu.Models;

namespace Tholumuntu.Controllers
{
    public class QuestionAnswerController : Controller
    {

        private readonly QuestionService _questionRepository;
        private readonly UserAnswerService _answerRepository;
        private readonly UserService _userService;
        public QuestionAnswerController()
        {
            _answerRepository = new UserAnswerService();
            _questionRepository = new QuestionService();
            _userService = new UserService();

        }

        public ActionResult Index()
        {
            var model = GetQuestionModel();
            return View(model);
        }

        private QuestionAnswerModel GetQuestionModel()
        {
            var choices = Enum.GetValues(typeof(Choice)).Cast<Choice>();
            var loveLanguages = Enum.GetValues(typeof(LoveLanguage)).Cast<LoveLanguage>();
            var horoscopes = Enum.GetValues(typeof(Horoscope)).Cast<Horoscope>();

            var horoscopeList = horoscopes.Select(
                item => new SelectListItem
                {
                    Selected = false,
                    Text = item.GetEnumDescription(),
                    Value = ((int)item).ToString()
                }).ToList();

            var loveLanguageList = loveLanguages.Select(
                item => new SelectListItem
                {
                    Selected = false,
                    Text = item.GetEnumDescription(),
                    Value = ((int)item).ToString()
                }).ToList();

            var choiceItems = choices.Select(
                item => new SelectListItem
                {
                    Selected = false,
                    Text = item.GetEnumDescription(),
                    Value = ((int)item).ToString()
                }).ToList();

            var questions = _questionRepository.GetAllQuestions();
            var questionModel = new QuestionModel
            {
                Occupation = questions.Single(x => x.Id == 1),
                Smoke = questions.Single(x => x.Id == 3),
                PersonalPreference = questions.Single(x => x.Id == 4),
                Iprefer = questions.Single(x => x.Id == 5),
                ValueTheMost = questions.Single(x => x.Id == 11),
                WhatIsYourReligion = questions.Single(x => x.Id == 10),
                Iam = questions.Single(x => x.Id == 6),
                IamGuiltyOf = questions.Single(x => x.Id == 8),
                IconsiderMyself = questions.Single(x => x.Id == 7),
                IdealDate = questions.Single(x => x.Id == 12),
                IfeelLoveAndAppreciated = questions.Single(x => x.Id == 17),
                //DoYouLiveIn = questions.Single(x => x.Id == 5),
                //PersonalInterest = questions.Single(x => x.Id == 5),
                DateDifferentBelief = questions.Single(x => x.Id == 14),
                DateOutsideEthnicGroup = questions.Single(x => x.Id == 15),
                DateSomeoneWithKids = questions.Single(x => x.Id == 13),
                DescribeYourSelf = questions.Single(x => x.Id == 5),
                //HowFriendsDescribeYou = questions.Single(x => x.Id == 5),
                WordDescribeYouBest = questions.Single(x => x.Id == 18),
                WordDescribeYouBest2 = questions.Single(x => x.Id == 19),
                WordDescribeYouBest3 = questions.Single(x => x.Id == 20),
                Ethnicity = questions.Single(x => x.Id == 9),
                AreYouArtistic = questions.Single(x => x.Id == 21),
                DoYouBelieveInFate = questions.Single(x => x.Id == 22),
                Answer = new AnswerModel()

            };
            var model = new QuestionAnswerModel
            {
                ChoiceItemList = choiceItems,
                HoroscopeItemList = horoscopeList,
                LoveLanguageList = loveLanguageList,
                QuestionModel = questionModel,
                
            };

            return model;
        }
        public ActionResult SaveAnswers(Dictionary<string, string> answers)
        {
            var userId = 1023;//Convert.ToInt32(Session["UserId"]);
            var check = _answerRepository.List(userId);

            if (check.Count == 0)
                AddAnswersToDatabase(answers, userId);
            else
            {
                _answerRepository.RemoveAll(check.ToList());
                AddAnswersToDatabase(answers, userId);
            }

            return Json(new {success = true, JsonRequestBehavior.AllowGet});
        }

        private void AddAnswersToDatabase(Dictionary<string, string> answers, int userId)
        {
            var listOfAnswers = new List<UserAnswer>();

            foreach (var answer in answers)
            {
                var questionId = Convert.ToInt32(answer.Key);
                var answerToQuestion = answer.Value;

                var userAnswer = new UserAnswer
                {
                    UserId = userId,
                    QuestionId = questionId,
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                    Answer = answerToQuestion
                };

                listOfAnswers.Add(userAnswer);
            }

            _answerRepository.Add(listOfAnswers);
        }

        public ActionResult UpdateAnswers()
        {
            var userId = 1023;//Convert.ToInt32(Session["UserId"]);
            var model = GetQuestionModel();

            var userAnswers = _answerRepository.List(userId);

            model.QuestionModel.Answer.Ethnicity = userAnswers.SingleOrDefault(x => x.QuestionId == model.QuestionModel.Ethnicity.Id)?.Answer;
            model.QuestionModel.Answer.Occupation = userAnswers.SingleOrDefault(x => x.QuestionId == model.QuestionModel.Occupation.Id)?.Answer;
            model.QuestionModel.Answer.Smoke = userAnswers.SingleOrDefault(x => x.QuestionId == model.QuestionModel.Smoke.Id)?.Answer;
            model.QuestionModel.Answer.WhatIsYourReligion = userAnswers.SingleOrDefault(x => x.QuestionId == model.QuestionModel.WhatIsYourReligion.Id)?.Answer;
            model.QuestionModel.Answer.ValueTheMost = userAnswers.SingleOrDefault(x => x.QuestionId == model.QuestionModel.ValueTheMost.Id)?.Answer;
            model.QuestionModel.Answer.AreYouArtistic = userAnswers.SingleOrDefault(x => x.QuestionId == model.QuestionModel.AreYouArtistic.Id)?.Answer;
            model.QuestionModel.Answer.IfeelLoveAndAppreciated = userAnswers.SingleOrDefault(x => x.QuestionId == model.QuestionModel.IfeelLoveAndAppreciated.Id)?.Answer;
            model.QuestionModel.Answer.Iam = userAnswers.SingleOrDefault(x => x.QuestionId == model.QuestionModel.Iam.Id)?.Answer;
            model.QuestionModel.Answer.IamGuiltyOf = userAnswers.SingleOrDefault(x => x.QuestionId == model.QuestionModel.IamGuiltyOf.Id)?.Answer;
            model.QuestionModel.Answer.IconsiderMyself = userAnswers.SingleOrDefault(x => x.QuestionId == model.QuestionModel.IconsiderMyself.Id)?.Answer;
            model.QuestionModel.Answer.IdealDate = userAnswers.SingleOrDefault(x => x.QuestionId == model.QuestionModel.IdealDate.Id)?.Answer;
            model.QuestionModel.Answer.Iprefer = userAnswers.SingleOrDefault(x => x.QuestionId == model.QuestionModel.Iprefer.Id)?.Answer;
            model.QuestionModel.Answer.DoYouBelieveInFate = userAnswers.SingleOrDefault(x => x.QuestionId == model.QuestionModel.DoYouBelieveInFate.Id)?.Answer;
            model.QuestionModel.Answer.DateDifferentBelief = userAnswers.SingleOrDefault(x => x.QuestionId == model.QuestionModel.DateDifferentBelief.Id)?.Answer;
            model.QuestionModel.Answer.DateOutsideEthnicGroup = userAnswers.SingleOrDefault(x => x.QuestionId == model.QuestionModel.DateOutsideEthnicGroup.Id)?.Answer;
            model.QuestionModel.Answer.DateSomeoneWithKids = userAnswers.SingleOrDefault(x => x.QuestionId == model.QuestionModel.DateSomeoneWithKids.Id)?.Answer;
            model.QuestionModel.Answer.PersonalPreference = userAnswers.SingleOrDefault(x => x.QuestionId == model.QuestionModel.PersonalPreference.Id)?.Answer;
            model.QuestionModel.Answer.WordDescribeYouBest = userAnswers.SingleOrDefault(x => x.QuestionId == model.QuestionModel.WordDescribeYouBest.Id)?.Answer;
            model.QuestionModel.Answer.WordDescribeYouBest2 = userAnswers.SingleOrDefault(x => x.QuestionId == model.QuestionModel.WordDescribeYouBest2.Id)?.Answer;
            model.QuestionModel.Answer.WordDescribeYouBest3 = userAnswers.SingleOrDefault(x => x.QuestionId == model.QuestionModel.WordDescribeYouBest3.Id)?.Answer;
            
            return View(model);
        }
    }
}