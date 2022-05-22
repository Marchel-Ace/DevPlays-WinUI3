using DevPlays_WinUI3.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace DevPlays_WinUI3.Views
{
    public sealed partial class RegexTesterPage : Page
    {
        public RegexTesterViewModel ViewModel { get; }

        public RegexTesterPage()
        {
            ViewModel = App.GetService<RegexTesterViewModel>();
            InitializeComponent();
        }
    }
}
