using DevPlays_WinUI3.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace DevPlays_WinUI3.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel{ get; }
        public string Header => "DevPlays";
        public MainPage()        
        {
            ViewModel = App.GetService<MainViewModel>();
            InitializeComponent();
        }
    }
}
