using DevPlays_WinUI3.ViewModels;
using System.IdentityModel.Tokens.Jwt;
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

        // Decode JWT Token and display Header, Payload, and Signature
        private string[] DecodeJWT(string jwt)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwt);
            var header = token.Header;
            var payload = token.Payload;
            var signature = token.RawSignature;

            return new string[] { header.ToString(), payload.ToString(), signature.ToString() };
        }



    }
}
