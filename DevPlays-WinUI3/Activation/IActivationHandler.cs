using System.Threading.Tasks;

namespace DevPlays_WinUI3.Activation
{
    public interface IActivationHandler
    {
        bool CanHandle(object args);

        Task HandleAsync(object args);
    }
}
