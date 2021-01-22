using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Eventos.IO.Domain.Eventos.Events
{
    public class EventoEventHandler :
        INotificationHandler<EventoRegistradoEvent>,
        INotificationHandler<EventoAtualizadoEvent>,
        INotificationHandler<EventoExcluidoEvent>,
        INotificationHandler<EnderecoEventoAdicionadoEvent>,
        INotificationHandler<EnderecoEventoAtualizadoEvent>
    {
        public Task Handle(EventoRegistradoEvent message, CancellationToken cancellationToken)
        {
            // TODO: Disparar alguma ação
            return Task.CompletedTask;
        }

        public Task Handle(EventoAtualizadoEvent message, CancellationToken cancellationToken)
        {
            // TODO: Disparar alguma ação
            return Task.CompletedTask;
        }

        public Task Handle(EventoExcluidoEvent message, CancellationToken cancellationToken)
        {
            // TODO: Disparar alguma ação
            return Task.CompletedTask;
        }

        public Task Handle(EnderecoEventoAdicionadoEvent message, CancellationToken cancellationToken)
        {
            // TODO: Disparar alguma ação
            return Task.CompletedTask;
        }

        public Task Handle(EnderecoEventoAtualizadoEvent message, CancellationToken cancellationToken)
        {
            // TODO: Disparar alguma ação
            return Task.CompletedTask;
        }
    }
}