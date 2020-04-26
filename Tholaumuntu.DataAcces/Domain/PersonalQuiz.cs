namespace Tholaumuntu.DataAcces.Domain
{
    public class PersonalQuiz : Entity
    {
        public virtual int UserId { get; set; }
        public string WordsThatDescribesMe { get; set; }
        public Choice ChoiceBetweenMoneyLoveHappiness { get; set; }
        public string AttractiveInPartner { get; set; }

        public PersonalQuiz()       
        {}

        public PersonalQuiz(PersonalQuiz quiz)
        {
            WordsThatDescribesMe = quiz.WordsThatDescribesMe;
            ChoiceBetweenMoneyLoveHappiness = quiz.ChoiceBetweenMoneyLoveHappiness;
            AttractiveInPartner = quiz.AttractiveInPartner;
        }
    }
}