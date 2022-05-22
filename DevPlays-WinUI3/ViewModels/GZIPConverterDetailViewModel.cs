using System;
using System.Linq;

using CommunityToolkit.Mvvm.ComponentModel;

using DevPlays_WinUI3.Contracts.ViewModels;
using DevPlays_WinUI3.Core.Contracts.Services;
using DevPlays_WinUI3.Core.Models;

namespace DevPlays_WinUI3.ViewModels
{
    public class GZIPConverterDetailViewModel : ObservableRecipient, INavigationAware
    {
        private readonly ISampleDataService _sampleDataService;
        private SampleOrder _item;

        public SampleOrder Item
        {
            get { return _item; }
            set { SetProperty(ref _item, value); }
        }

        public GZIPConverterDetailViewModel(ISampleDataService sampleDataService)
        {
            _sampleDataService = sampleDataService;
        }

        public async void OnNavigatedTo(object parameter)
        {
            if (parameter is long orderID)
            {
                var data = await _sampleDataService.GetContentGridDataAsync();
                Item = data.First(i => i.OrderID == orderID);
            }
        }

        public void OnNavigatedFrom()
        {
        }
    }
}
