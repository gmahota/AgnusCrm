using System.Linq;
using AgnusCrm.Domain.Interfaces;
using AgnusCrm.Domain.Models;
using AgnusCrm.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AgnusCrm.Infra.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AgnusCrmContext context)
            : base(context)
        {

        }

        public Customer GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Email == email);
        }
    }
}
