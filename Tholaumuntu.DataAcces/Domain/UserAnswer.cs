using System.Reflection;

namespace Tholaumuntu.DataAcces.Domain
{
    public class UserAnswer: Entity
    {
        public virtual int QuestionId { get; set; }
        public string Answer { get; set; }
        public virtual int UserId { get; set; }
    }
}