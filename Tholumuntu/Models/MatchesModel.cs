using System.Collections.Generic;
using Tholaumuntu.DataAcces.Domain;

namespace Tholumuntu.Models
{
    public class MatchesModel
    {
        public string Count { get; set; }
        public User User { get; set; }
        public List<User> Matches { get; set; }

        public string Location { get; set; }
        public string Age { get; set; }
        public MatchesModel()
        {
            
        }
    }

    public class MatchingUser       
    {
        public List<User> Users { get; set; }
        public string Age { get; set; }
        public string AboutMe { get; set; }
        public string Location { get; set; }    

    }
}