using AgnusCrm.Domain.Models;

namespace AgnusCrm.Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByEmail(string email);
    }
}