using System;

namespace DevPlays_WinUI3.Contracts.Services
{
    public interface IPageService
    {
        Type GetPageType(string key);
    }
}
