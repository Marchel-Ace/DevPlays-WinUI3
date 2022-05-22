using DevPlays_WinUI3.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace DevPlays_WinUI3.Views
{
    public sealed partial class NumberBasePage : Page
    {
        public NumberBaseViewModel ViewModel { get; }

        public NumberBasePage()
        {
            ViewModel = App.GetService<NumberBaseViewModel>();
            InitializeComponent();
        }
    }
}
