using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DevPlays_WinUI3.Core.Models;
namespace DevPlays_WinUI3.Core.Contracts.Services
{
    public interface IMenuNavigationDataService
    {
        Task<IEnumerable<MenuNavigation>> GetContentGridDataAsync();


    }
}
