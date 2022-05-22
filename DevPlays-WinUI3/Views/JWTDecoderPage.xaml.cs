using DevPlays_WinUI3.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace DevPlays_WinUI3.Views
{
    public sealed partial class JWTDecoderPage : Page
    {
        public JWTDecoderViewModel ViewModel { get; }

        public JWTDecoderPage()
        {
            ViewModel = App.GetService<JWTDecoderViewModel>();
            InitializeComponent();
        }
    }
}
