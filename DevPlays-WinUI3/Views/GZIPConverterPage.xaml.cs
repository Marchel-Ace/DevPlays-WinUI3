using DevPlays_WinUI3.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace DevPlays_WinUI3.Views
{
    public sealed partial class GZIPConverterPage : Page
    {
        public GZIPConverterViewModel ViewModel { get; }

        public GZIPConverterPage()
        {
            ViewModel = App.GetService<GZIPConverterViewModel>();
            InitializeComponent();
        }
    }
}
