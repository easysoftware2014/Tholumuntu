using Tholaumuntu.DataAcces.Domain;

namespace Tholumuntu.Models
{
    public class UserModel
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ContactNumber { get; set; }
        public string Street { get; set; }
        public string State { get; set; }

        public UserModel(){}
        public UserModel(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Surname = user.Surname;
            ContactNumber = user.ContactNumber;
            Email = user.Email;
            Street = user.Street;
            State = user.State;
            Password = user.Password;
        }

        public void UpdatePassword(string password)
        {
            Password = password;
        }
    }
}