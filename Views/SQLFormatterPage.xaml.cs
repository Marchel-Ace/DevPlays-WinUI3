using DevPlays_WinUI3.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace DevPlays_WinUI3.Views
{
    public sealed partial class SQLFormatterPage : Page
    {
        public SQLFormatterViewModel ViewModel { get; }

        public SQLFormatterPage()
        {
            ViewModel = App.GetService<SQLFormatterViewModel>();
            InitializeComponent();
        }
    }
}
