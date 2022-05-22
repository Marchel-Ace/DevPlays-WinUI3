using DevPlays_WinUI3.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace DevPlays_WinUI3.Views
{
    public sealed partial class XMLFormatterPage : Page
    {
        public XMLFormatterViewModel ViewModel { get; }

        public XMLFormatterPage()
        {
            ViewModel = App.GetService<XMLFormatterViewModel>();
            InitializeComponent();
        }
    }
}
