using System;
using Tholaumuntu.DataAcces.Domain;

namespace Tholumuntu.Models
{
    public class UserProfileModel
    {
        public int UserProfId { get; set; }
        public UserModel User { get; set; }
        public LoveLanguage LoveLanguage { get; set; }
        public string Horoscope { get; set; }
        public Byte[] ProfilePicture { get; set; }
        public EntityStatus EntityStatus { get; set; }

        public UserProfileModel(){}

        public UserProfileModel(UserProfile model)
        {
            UserProfId = model.Id;
            LoveLanguage = model.LoveLanguage;
            Horoscope = model.Horoscope;
            ProfilePicture = model.ProfilePicture;
        }

        public void SetStatus(EntityStatus status)
        {
            EntityStatus = status;
        }
    }
}