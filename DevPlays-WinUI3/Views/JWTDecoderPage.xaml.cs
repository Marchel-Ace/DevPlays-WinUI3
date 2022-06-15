using DevPlays_WinUI3.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.UI.Xaml.Controls;
using System;
using Microsoft.UI.Xaml;
using System.Diagnostics;
using Newtonsoft.Json;

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
            JwtSecurityToken jwtSecurityToken = handler.ReadJwtToken(jwt);
            string header = JsonConvert.SerializeObject(jwtSecurityToken.Header, Formatting.Indented);
            string payload = JsonConvert.SerializeObject(jwtSecurityToken.Payload, Formatting.Indented);
            Debug.WriteLine(header);
            return new string[] { header, payload };

        }
        
       

        // Decode JWT Token and display Header, Payload, and Signature
        private void JWT_Changed(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(jwtEditBox.Text))
            {
                headerEditBox.Text = "";
                payloadEditBox.Text = "";
            }

            try
            {
                string jwt_text = jwtEditBox.Text;
                string[] decoded = DecodeJWT(jwt_text);
                Debug.WriteLine(decoded);
                headerEditBox.Text = decoded[0];
                payloadEditBox.Text = decoded[1];

            }
            catch (Exception ex)
            {
                payloadEditBox.Text = ex.Message;
                headerEditBox.Text = ex.Message;
            }




        }

    }
}
