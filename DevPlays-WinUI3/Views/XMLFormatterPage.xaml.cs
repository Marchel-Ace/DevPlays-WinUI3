using DevPlays_WinUI3.ViewModels;
using System.Xml;
using System.Text;
using System.IO;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;

using System;

namespace DevPlays_WinUI3.Views
{
    public sealed partial class XMLFormatterPage : Page
    {
        public XMLFormatterViewModel ViewModel { get; }

        public XMLFormatterPage()
        {
            ViewModel = App.GetService<XMLFormatterViewModel>();
            InitializeComponent();
        }

        public static string FormatXML(string inputXML)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(inputXML);

            StringBuilder builder = new StringBuilder();
            using (XmlTextWriter writer = new XmlTextWriter(new StringWriter(builder)))
            {
                writer.Formatting = Formatting.Indented;
                doc.Save(writer);
            }

            return builder.ToString();
        }

        public void XAML_Changed(object sender, RoutedEventArgs e)
        {
            string inputText = plainBox.Text;
            try
            {
                if (string.IsNullOrWhiteSpace(inputText))
                {
                    formattedBox.Text = "";
                    return;
                }
                else
                {
                    formattedBox.Text = FormatXML(inputText);
                }

            }catch (Exception ex)
            {
                formattedBox.Text = ex.Message;
            }
        }
    }
}
