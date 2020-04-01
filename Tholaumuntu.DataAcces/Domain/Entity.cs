using System;
using Tholaumuntu.DataAcces.Interfaces;

namespace Tholaumuntu.DataAcces.Domain
{
    public class Entity : IEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public int Id { get; set; }
    }
}