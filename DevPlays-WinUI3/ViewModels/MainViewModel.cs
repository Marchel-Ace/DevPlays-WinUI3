using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using DevPlays_WinUI3.Contracts.Services;
using DevPlays_WinUI3.Contracts.ViewModels;
using DevPlays_WinUI3.Core.Contracts.Services;
using DevPlays_WinUI3.Core.Models;

namespace DevPlays_WinUI3.ViewModels
{
    public class MainViewModel : ObservableRecipient, INavigationAware
    {

        private readonly INavigationService _navigationService;
        private readonly ISampleDataService _sampleDataService;
        private ICommand _itemClickCommand;

        public ICommand ItemClickCommand => _itemClickCommand ?? (_itemClickCommand = new RelayCommand<SampleOrder>(OnItemClick));

        public ObservableCollection<SampleOrder> Source { get; } = new ObservableCollection<SampleOrder>();

        public MainViewModel(INavigationService navigationService, ISampleDataService sampleDataService)
        {
            _navigationService = navigationService;
            _sampleDataService = sampleDataService;
        }

        public async void OnNavigatedTo(object parameter)
        {
            Source.Clear();

            // TODO: Replace with real data.
            var data = await _sampleDataService.GetContentGridDataAsync();
            foreach (var item in data)
            {
                Source.Add(item);
            }
        }

        public void OnNavigatedFrom()
        {
        }

        private void OnItemClick(SampleOrder clickedItem)
        {
            if (clickedItem != null)
            {
                _navigationService.SetListDataItemForNextConnectedAnimation(clickedItem);
                switch (clickedItem.NavigatedToName)
                {
                    case "0":
                        _navigationService.NavigateTo(typeof(NumberBaseViewModel).FullName, clickedItem.OrderID);
                        break;
                    case "1":
                        _navigationService.NavigateTo(typeof(SQLFormatterViewModel).FullName, clickedItem.OrderID);
                        break;
                    case "2":
                        _navigationService.NavigateTo(typeof(XMLFormatterViewModel).FullName, clickedItem.OrderID);
                        break;
                    case "3":
                        _navigationService.NavigateTo(typeof(JSONFormatterViewModel).FullName, clickedItem.OrderID);
                        break;
                    case "4":
                        _navigationService.NavigateTo(typeof(Base64ConverterViewModel).FullName, clickedItem.OrderID);
                        break;
                    case "5":
                        _navigationService.NavigateTo(typeof(GZIPConverterViewModel).FullName, clickedItem.OrderID);
                        break;
                    case "6":
                        _navigationService.NavigateTo(typeof(JWTDecoderViewModel).FullName, clickedItem.OrderID);
                        break;
                    case "7":
                        _navigationService.NavigateTo(typeof(TextDiffViewModel).FullName, clickedItem.OrderID);
                        break;
                    case "8":
                        _navigationService.NavigateTo(typeof(RegexTesterViewModel).FullName, clickedItem.OrderID);
                        break;
                    case "9":
                        _navigationService.NavigateTo(typeof(HashGeneratorViewModel).FullName, clickedItem.OrderID);
                        break;
                }
            }
        }
    }
}
