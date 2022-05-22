using DevPlays_WinUI3.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace DevPlays_WinUI3.Views
{
    public sealed partial class TextDiffPage : Page
    {
        public TextDiffViewModel ViewModel { get; }

        public TextDiffPage()
        {
            ViewModel = App.GetService<TextDiffViewModel>();
            InitializeComponent();
        }
    }
}
