namespace Tholaumuntu.DataAcces.Domain
{
    public class PersonalQuiz : Entity
    {
        public virtual User User { get; set; }

        public PersonalQuiz()
        {}

        public PersonalQuiz(PersonalQuiz quiz)
        {
            
        }
    }
}