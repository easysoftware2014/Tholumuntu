using System.Collections.Generic;
using System.Web.Mvc;
using Tholaumuntu.DataAcces.Domain;

namespace Tholumuntu.Models
{
    public class QuestionAnswerModel
    {
        public IList<SelectListItem> LoveLanguageList { get; set; }
        public IList<SelectListItem> ChoiceItemList { get; set; }
        public IList<SelectListItem> HoroscopeItemList { get; set; }
        public Choice ChoiceBetweenMoneyLoveHappiness { get; set; }
        public Horoscope Horoscope { get; set; }
        public LoveLanguage LoveLanguage { get; set; }
        public QuestionModel QuestionModel { get; set; }

        public QuestionAnswerModel()
        {}
    }
}