using CommunityToolkit.WinUI.UI.Animations;

using DevPlays_WinUI3.Contracts.Services;
using DevPlays_WinUI3.ViewModels;

using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

namespace DevPlays_WinUI3.Views
{
    public sealed partial class Base64ConverterDetailPage : Page
    {
        public Base64ConverterDetailViewModel ViewModel { get; }

        public Base64ConverterDetailPage()
        {
            ViewModel = App.GetService<Base64ConverterDetailViewModel>();
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.RegisterElementForConnectedAnimation("animationKeyContentGrid", itemHero);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            if (e.NavigationMode == NavigationMode.Back)
            {
                var navigationService = App.GetService<INavigationService>();
                navigationService.SetListDataItemForNextConnectedAnimation(ViewModel.Item);
            }
        }
    }
}
