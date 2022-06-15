using DevPlays_WinUI3.ViewModels;
using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using Microsoft.UI.Xaml.Controls;
using System.ComponentModel;
using Microsoft.UI.Xaml;

namespace DevPlays_WinUI3.Views
{
    public sealed partial class GZIPConverterPage : Page, INotifyPropertyChanged
    {
        public GZIPConverterViewModel ViewModel { get; }

        public GZIPConverterPage()
        {
            ViewModel = App.GetService<GZIPConverterViewModel>();
            InitializeComponent();

            _editorHeaderName = "Input";
            _readerHeaderName = "Output";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private string _editorHeaderName;
        private string _readerHeaderName;

        public string EditorHeaderName
        {
            get { return _editorHeaderName; }
            set
            {
                if (string.Equals(value, EditorHeaderName))
                    return;
                _editorHeaderName = value;
                OnPropertyChanged(nameof(EditorHeaderName));


            }
        }

        public string ReadHeaderName
        {
            get { return _readerHeaderName; }
            set
            {
                if (string.Equals(value, ReadHeaderName))
                    return;
                _readerHeaderName = value;
                OnPropertyChanged(nameof(ReadHeaderName));
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public void editorBox_Changed(object sender, RoutedEventArgs e)
        {

            string inputText = editorBox.Text;
            
            if (string.IsNullOrWhiteSpace(inputText))
            {
                readBox.Text = "";
                return;
            }


            try{
                if (GzipSwitch.IsOn)
                {
                    string decompressed = Decompress(inputText);
                    readBox.Text = decompressed;

                }
                else
                {
                    string compressed = Compress(inputText);
                    readBox.Text = compressed;

                }

            }
            catch(Exception ex)
            {
                readBox.Text = ex.Message;
            }
        }

        public void Gzip_Changed(object sender, RoutedEventArgs e)
        {
            string inputText = readBox.Text;

            if (string.IsNullOrWhiteSpace(inputText))
            {
                readBox.Text = "";
                return;
            }

            try
            {
                if (GzipSwitch.IsOn) {
                    string decompressed = Decompress(inputText);
                    editorBox.Text = inputText;
                    readBox.Text = decompressed;
                }
                else
                {

                    string compressed = Compress(inputText);
                    editorBox.Text = inputText;
                    readBox.Text = compressed;

                }
            }
            catch (Exception ex)
            {
                readBox.Text = ex.Message;
            }

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
