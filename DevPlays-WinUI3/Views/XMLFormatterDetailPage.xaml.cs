using CommunityToolkit.WinUI.UI.Animations;

using DevPlays_WinUI3.Contracts.Services;
using DevPlays_WinUI3.ViewModels;

using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

namespace DevPlays_WinUI3.Views
{
    public sealed partial class XMLFormatterDetailPage : Page
    {
        public XMLFormatterDetailViewModel ViewModel { get; }

        public XMLFormatterDetailPage()
        {
            ViewModel = App.GetService<XMLFormatterDetailViewModel>();
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
