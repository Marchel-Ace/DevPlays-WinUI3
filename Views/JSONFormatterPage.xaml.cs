using DevPlays_WinUI3.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace DevPlays_WinUI3.Views
{
    public sealed partial class JSONFormatterPage : Page
    {
        public JSONFormatterViewModel ViewModel { get; }

        public JSONFormatterPage()
        {
            ViewModel = App.GetService<JSONFormatterViewModel>();
            InitializeComponent();
        }
    }
}
