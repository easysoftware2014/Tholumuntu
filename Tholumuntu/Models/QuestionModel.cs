using Tholaumuntu.DataAcces.Domain;

namespace Tholumuntu.Models
{
    public class QuestionModel
    {
        public Question Occupation { get; set; }
        public Question Smoke { get; set; }
        public Question PersonalPreference { get; set; }
        public Question ValueTheMost { get; set; }
        public Question Iam { get; set; }
        public Question Iprefer { get; set; }
        public Question AreYouArtistic { get; set; }
        public Question BelieveInFaith { get; set; }
        public Question IdealDate { get; set; }
        public Question DateSomeoneWithKids { get; set; }
        public Question IconsiderMyself { get; set; }
        public Question IamGuiltyOf { get; set; }
        public Question IfeelLoveAndAppreciated { get; set; }
        public Question Ethnicity { get; set; }
        public Question DateOutsideEthnicGroup { get; set; }
        public Question WhatIsYourReligion { get; set; }
        public Question DateDifferentBelief { get; set; }
        public Question WordDescribeYouBest { get; set; }
        public Question WordDescribeYouBest2 { get; set; }
        public Question WordDescribeYouBest3 { get; set; }
        public Question DoYouLiveIn { get; set; }
        public Question PersonalInterest { get; set; }
        public Question DescribeYourSelf { get; set; }
        public Question HowFriendsDescribeYou { get; set; }
        public Question FavoriteQuote { get; set; }
        public Question DoYouBelieveInFate { get; set; }
        public AnswerModel Answer { get; set; }

        public QuestionModel()
        {}

    }

    public class AnswerModel
    {
        public string Occupation { get; set; }
        public string Smoke { get; set; }
        public string PersonalPreference { get; set; }
        public string ValueTheMost { get; set; }
        public string Iam { get; set; }
        public string Iprefer { get; set; }
        public string AreYouArtistic { get; set; }
        public string BelieveInFaith { get; set; }
        public string IdealDate { get; set; }
        public string DateSomeoneWithKids { get; set; }
        public string IconsiderMyself { get; set; }
        public string IamGuiltyOf { get; set; }
        public string IfeelLoveAndAppreciated { get; set; }
        public string Ethnicity { get; set; }
        public string DateOutsideEthnicGroup { get; set; }
        public string WhatIsYourReligion { get; set; }
        public string DateDifferentBelief { get; set; }
        public string WhichDoYouValueMost { get; set; }
        public string WordDescribeYouBest { get; set; }
        public string WordDescribeYouBest2 { get; set; }
        public string WordDescribeYouBest3 { get; set; }
        public string DoYouLiveIn { get; set; }
        public string PersonalInterest { get; set; }
        public string DescribeYourSelf { get; set; }
        public string HowFriendsDescribeYou { get; set; }
        public string FavoriteQuote { get; set; }
        public string DoYouBelieveInFate { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Choice { get; set; }
        public string LoveLanguage { get; set; }
        public string Gender { get; set; }
        public string Horoscope { get; set; }
        public string DateOfBirth { get; set; }
    }
}