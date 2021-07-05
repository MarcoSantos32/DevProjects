using Stech.Clientes.Domain.Interfaces;
using System;

namespace Stech.Clientes.Domain.Base
{
    public abstract class Entity : IEntity
    {
        public Guid ID { get;  set; }

        protected Entity()
        {
            ID = Guid.NewGuid();
        }
    }
}
