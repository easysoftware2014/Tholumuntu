using Tholaumuntu.DataAcces.Domain;

namespace Tholumuntu.Models
{
    public class UserProfileModel
    {
        public int UserProfId { get; set; }
        public UserModel User { get; set; }
        public LoveLanguage LoveLanguage { get; set; }
        public string Horoscope { get; set; }   
    }
}