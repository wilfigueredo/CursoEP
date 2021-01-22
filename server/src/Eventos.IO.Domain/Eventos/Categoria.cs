using System;
using System.Collections.Generic;
using Eventos.IO.Domain.Core.Models;

namespace Eventos.IO.Domain.Eventos
{
    public class Categoria : Entity<Categoria>
    {
        public Categoria(Guid id)
        {
            Id = id;
        }

        public string Nome { get; private set; }

        // EF Propriedade de Navegação
        public virtual ICollection<Evento> Eventos { get; set; }

        // Construtor para o EF
        protected Categoria() { }

        public override bool EhValido()
        {
            return true;
        }
    }
}