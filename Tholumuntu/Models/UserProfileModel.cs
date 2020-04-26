using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.Mvc;
using Tholaumuntu.DataAcces.Domain;

namespace Tholumuntu.Models
{
    public class UserProfileModel
    {
        public int UserProfId { get; set; }
        public User User { get; set; }
        public LoveLanguage LoveLanguage { get; set; }
        public string Horoscope { get; set; }
        public Byte[] ProfilePicture { get; set; }
        public EntityStatus EntityStatus { get; set; }
        public string Gender { get; set; }
        public virtual Address Address { get; set; }
        public PersonalQuizModel Quiz { get; set; }
        public string SelectedDropdownValue { get; set; }
        public string SelectedDropdownValueForLove { get; set; }
        public IList<SelectListItem> LoveLanguageList { get; set; }
        public IList<SelectListItem> ChoiceItemList { get; set; }
        public IList<SelectListItem> HoroscopeItemList { get; set; }
        public Image Image { get; set; }
        public string FullName { get; set; }
        public UserProfileModel()
        {
            Quiz = new PersonalQuizModel();
        }

        public UserProfileModel(UserProfile model)
        {
            UserProfId = model.Id;
            LoveLanguage = model.LoveLanguage;
            Horoscope = model.Horoscope;
            ProfilePicture = model.ProfilePicture;
            Gender = model.Gender;
            //Quiz = model.Quiz;
            
        }

        public void SetAddress(Address address)
        {
            Address = address;
        }
        public void SetStatus(EntityStatus status)
        {
            EntityStatus = status;
        }

        public void SetUser(User user)
        {
            User = user;
        }

        public string GetFullName(User user)
        {
            return FullName = user.Name + " " + user.Surname;
        }
    }
}