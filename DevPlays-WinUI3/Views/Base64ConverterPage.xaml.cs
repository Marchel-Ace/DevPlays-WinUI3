using DevPlays_WinUI3.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.ComponentModel;
using System.Diagnostics;
using System;


namespace DevPlays_WinUI3.Views
{
    public sealed partial class Base64ConverterPage : Page, INotifyPropertyChanged
    {
        public Base64ConverterViewModel ViewModel { get; }

        public Base64ConverterPage()
        {
            ViewModel = App.GetService<Base64ConverterViewModel>();
            InitializeComponent();
            EditorHeaderName = "Encoded";
            ReadHeaderName = "Decoded";
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
            try
            {
                if (baseModeSwitch.IsOn)
                {
                    string EncodedBase64 = editorBox.Text;
                    string DecodedBase64 = Base64Decode(EncodedBase64);
                    readBox.Text = DecodedBase64;
                }
                else
                {
                    string DecodedBase64 = editorBox.Text;
                    string EncodedBase64 = Base64Encode(DecodedBase64);
                    readBox.Text = EncodedBase64;
                }
            }
            catch (Exception ex)
            {
                readBox.Text = ex.Message;
            }         
        }
        
        public void baseMode_Changed(object sender, RoutedEventArgs e)
        {

            if (baseModeSwitch.IsOn)
            {
                ReadHeaderName = "Decoded";
                EditorHeaderName = "Encoded";
                
                if (string.IsNullOrWhiteSpace(editorBox.Text))
                {
                    return;
                }
                
                try
                {
                    string EncodedBase64 = readBox.Text;
                    string DecodedBase64 = Base64Decode(EncodedBase64);
                    editorBox.Text = readBox.Text;
                    readBox.Text = DecodedBase64;
                }
                catch (Exception ex)
                {
                    readBox.Text = ex.Message;
                }
            }
            else
            {
                ReadHeaderName = "Encoded";
                EditorHeaderName = "Decoded";
                
                if (string.IsNullOrWhiteSpace(editorBox.Text))
                {
                    return;
                }

                try
                {
                    string DecodedBase64 = readBox.Text;
                    string EncodedBase64 = Base64Encode(DecodedBase64);
                    editorBox.Text = readBox.Text;
                    readBox.Text = EncodedBase64;
                }
                catch (Exception ex)
                {
                    readBox.Text = ex.Message;
                }
            }
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
