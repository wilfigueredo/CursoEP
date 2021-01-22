using System.Threading.Tasks;
using Eventos.IO.Domain.Core.Commands;
using Eventos.IO.Domain.Core.Events;

namespace Eventos.IO.Domain.Interfaces
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task EnviarComando<T>(T comando) where T : Command;
    }
}