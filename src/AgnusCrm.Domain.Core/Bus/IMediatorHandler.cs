using System.Threading.Tasks;
using AgnusCrm.Domain.Core.Commands;
using AgnusCrm.Domain.Core.Events;


namespace AgnusCrm.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
