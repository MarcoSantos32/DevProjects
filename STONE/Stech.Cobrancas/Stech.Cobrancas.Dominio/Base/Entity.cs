using System;
using Stech.Cobrancas.Dominio.Interfaces;

namespace Stech.Cobrancas.Dominio.Base
{
    public abstract class Entity : IEntity
    {

        public Guid ID { get; set; }


        public Entity()
        {
            ID = Guid.NewGuid();
        }

    }
}
