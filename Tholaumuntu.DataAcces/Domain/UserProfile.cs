using System;

namespace Tholaumuntu.DataAcces.Domain
{
    public class UserProfile : Entity
    {
        public User User;
        public string Image;
        public virtual int UserId { get; set; }
        public LoveLanguage LoveLanguage { get; set; }
        public string Horoscope { get; set; }
        public EntityStatus EntityStatus { get; set; }
        public string PersonalityType { get; set; }
        public Choice ChoiceBetweenMoneyLoveHappiness { get; set; }
        public Byte[] ProfilePicture { get; set; }
        public string Gender { get; set; }
        public int QuizId { get; set; }
        public string PersonalInterest { get; set; }
        public string DescribeYourself { get; set; }
        public string FriendsDescribeYou { get; set; }
        public string FavoriteQuote { get; set; }
    }
    
}