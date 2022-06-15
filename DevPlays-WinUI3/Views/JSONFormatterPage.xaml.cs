using DevPlays_WinUI3.ViewModels;
using Newtonsoft.Json;
using Microsoft.UI.Xaml.Controls;
using System;
using Microsoft.UI.Xaml;

namespace DevPlays_WinUI3.Views
{
    public sealed partial class JSONFormatterPage : Page
    {
        public JSONFormatterViewModel ViewModel { get; }

        public JSONFormatterPage()
        {
            ViewModel = App.GetService<JSONFormatterViewModel>();
            InitializeComponent();
        }

        private string FormatJson(string json)
        {
            dynamic parsedJson = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
        }

        private void JWT_Changed(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(plainBox.Text)){
                formattedBox.Text = "";
                return;
            }
            try
            {
                string formattedJson = FormatJson(plainBox.Text);
                formattedBox.Text = formattedJson;
            }
            catch (Exception ex)
            {
                formattedBox.Text = ex.Message;
            }
        }
    }
}
