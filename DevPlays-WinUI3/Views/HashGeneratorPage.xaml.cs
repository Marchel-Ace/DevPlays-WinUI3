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
        
        private string MD5Hash(string inputText)
        {
            var md5 = System.Security.Cryptography.MD5.Create();
            var inputBytes = System.Text.Encoding.ASCII.GetBytes(inputText);
            var hash = md5.ComputeHash(inputBytes);
            var sb = new System.Text.StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        private string SHA1Hash(string inputText)
        {
            var sha1 = System.Security.Cryptography.SHA1.Create();
            var inputBytes = System.Text.Encoding.ASCII.GetBytes(inputText);
            var hash = sha1.ComputeHash(inputBytes);
            var sb = new System.Text.StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        private string SHA256Hash(string inputText)
        {
            var sha256 = System.Security.Cryptography.SHA256.Create();
            var inputBytes = System.Text.Encoding.ASCII.GetBytes(inputText);
            var hash = sha256.ComputeHash(inputBytes);
            var sb = new System.Text.StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        private string SHA512Hash(string inputText)
        {
            var sha512 = System.Security.Cryptography.SHA512.Create();
            var inputBytes = System.Text.Encoding.ASCII.GetBytes(inputText);
            var hash = sha512.ComputeHash(inputBytes);
            var sb = new System.Text.StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        private void Hash_Changed(object sender, TextChangedEventArgs e)
        {
            string hash = hashEditBox.Text;
            
            if(string.IsNullOrWhiteSpace(hash)){
                return;
            }

            MD5Text.Text = MD5Hash(hash);
            SHA1Text.Text = SHA1Hash(hash);
            SHA256Text.Text = SHA256Hash(hash);
            SHA512Text.Text = SHA512Hash(hash);
            
        }

    }
}
