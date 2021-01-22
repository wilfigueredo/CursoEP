using System;
using System.Collections.Generic;
using Eventos.IO.Domain.Core.Events;

namespace Eventos.IO.Infra.Data.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}