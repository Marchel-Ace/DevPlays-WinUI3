using DevPlays_WinUI3.ViewModels;
using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using Microsoft.UI.Xaml.Controls;

namespace DevPlays_WinUI3.Views
{
    public sealed partial class GZIPConverterPage : Page
    {
        public GZIPConverterViewModel ViewModel { get; }

        public GZIPConverterPage()
        {
            ViewModel = App.GetService<GZIPConverterViewModel>();
            InitializeComponent();
        }

        public string Compress(string input)
        {
            var bytes = Encoding.Unicode.GetBytes(input);
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(mso, CompressionMode.Compress))
                {
                    msi.CopyTo(gs);
                }
                return Convert.ToBase64String(mso.ToArray());
            }
        }

        public string Decompress(string input)
        {
            var bytes = Convert.FromBase64String(input);
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                {
                    gs.CopyTo(mso);
                }
                return Encoding.Unicode.GetString(mso.ToArray());
            }
        }
    }
}
