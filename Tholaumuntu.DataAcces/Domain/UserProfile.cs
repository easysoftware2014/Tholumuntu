namespace Tholaumuntu.DataAcces.Domain
{
    public class UserProfile : Entity
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public LoveLanguage LoveLanguage { get; set; }
        public string Horoscope { get; set; }
        public EntityStatus EntityStatus { get; set; }
        public string PersonalityType { get; set; } 

    }
}