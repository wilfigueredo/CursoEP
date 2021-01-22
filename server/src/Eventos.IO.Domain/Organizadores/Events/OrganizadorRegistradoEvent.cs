using System;
using Eventos.IO.Domain.Core.Events;

namespace Eventos.IO.Domain.Organizadores.Events
{
    public class OrganizadorRegistradoEvent : Event
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }

        public OrganizadorRegistradoEvent(Guid id, string nome, string cpf, string email)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            Email = email;
        }
    }
}