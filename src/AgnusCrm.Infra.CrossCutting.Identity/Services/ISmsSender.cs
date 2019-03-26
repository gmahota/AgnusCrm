using System.Threading.Tasks;

namespace AgnusCrm.Infra.CrossCutting.Identity.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
