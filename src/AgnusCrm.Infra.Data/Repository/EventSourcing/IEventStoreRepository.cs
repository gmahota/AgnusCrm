using System;
using System.Collections.Generic;
using AgnusCrm.Domain.Core.Events;

namespace AgnusCrm.Infra.Data.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}