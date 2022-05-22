using DevPlays_WinUI3.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace DevPlays_WinUI3.Views
{
    public sealed partial class Base64ConverterPage : Page
    {
        public Base64ConverterViewModel ViewModel { get; }

        public Base64ConverterPage()
        {
            ViewModel = App.GetService<Base64ConverterViewModel>();
            InitializeComponent();
        }
    }
}
