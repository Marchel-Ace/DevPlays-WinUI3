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

        public string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
