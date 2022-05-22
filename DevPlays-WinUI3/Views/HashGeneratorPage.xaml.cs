using DevPlays_WinUI3.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace DevPlays_WinUI3.Views
{
    public sealed partial class HashGeneratorPage : Page
    {
        public HashGeneratorViewModel ViewModel { get; }

        public HashGeneratorPage()
        {
            ViewModel = App.GetService<HashGeneratorViewModel>();
            InitializeComponent();
        }
    }
}
