using System;

namespace Tholaumuntu.DataAcces.Interfaces
{
    public interface IEntity
    {
        DateTime CreatedAt { get; set; }
        DateTime ModifiedAt { get; set; }
    }
}