using System.Collections.Generic;
using System.Threading.Tasks;

using DevPlays_WinUI3.Core.Models;

namespace DevPlays_WinUI3.Core.Contracts.Services
{
    // Remove this class once your pages/features are using your data.
    public interface ISampleDataService
    {
        Task<IEnumerable<SampleOrder>> GetContentGridDataAsync();
    }
}
