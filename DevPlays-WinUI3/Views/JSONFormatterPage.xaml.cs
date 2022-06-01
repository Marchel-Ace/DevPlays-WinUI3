using DevPlays_WinUI3.ViewModels;
using Newtonsoft.Json;
using Microsoft.UI.Xaml.Controls;

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
    }
}
