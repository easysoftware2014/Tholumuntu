using Tholaumuntu.DataAcces.Domain;

namespace Tholumuntu.Models
{
    public class PersonalQuizModel
    {
        public int Id { get; set; }
        public string WordsThatDescribesMe { get; set; }
        public Choice ChoiceBetweenMoneyLoveHappiness { get; set; }
        public string AttractiveInPartner { get; set; }
        public string Choice { get; set; }
        public string Words { get; set; }
      
        public PersonalQuizModel()
        {
            
        }
        public PersonalQuizModel(PersonalQuiz quiz)
        {
            WordsThatDescribesMe = quiz.WordsThatDescribesMe;
            ChoiceBetweenMoneyLoveHappiness = quiz.ChoiceBetweenMoneyLoveHappiness;
            AttractiveInPartner = quiz.AttractiveInPartner;
            Id = quiz.Id;
        }
    }
}