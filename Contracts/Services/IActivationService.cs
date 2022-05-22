using System.Threading.Tasks;

namespace DevPlays_WinUI3.Contracts.Services
{
    public interface IActivationService
    {
        Task ActivateAsync(object activationArgs);
    }
}
