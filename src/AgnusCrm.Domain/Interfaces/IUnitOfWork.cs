using System;

namespace AgnusCrm.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
