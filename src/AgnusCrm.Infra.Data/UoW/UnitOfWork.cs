using AgnusCrm.Domain.Interfaces;
using AgnusCrm.Infra.Data.Context;

namespace AgnusCrm.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AgnusCrmContext _context;

        public UnitOfWork(AgnusCrmContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
