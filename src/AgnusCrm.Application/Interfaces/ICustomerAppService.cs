using System;
using System.Collections.Generic;
using AgnusCrm.Application.EventSourcedNormalizers;
using AgnusCrm.Application.ViewModels;

namespace AgnusCrm.Application.Interfaces
{
    public interface ICustomerAppService : IDisposable
    {
        void Register(CustomerViewModel customerViewModel);
        IEnumerable<CustomerViewModel> GetAll();
        CustomerViewModel GetById(Guid id);
        void Update(CustomerViewModel customerViewModel);
        void Remove(Guid id);
        IList<CustomerHistoryData> GetAllHistory(Guid id);
    }
}
