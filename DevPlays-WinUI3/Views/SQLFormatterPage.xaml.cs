using DevPlays_WinUI3.ViewModels;
using NSQLFormatter;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using System;

namespace DevPlays_WinUI3.Views
{
    public sealed partial class SQLFormatterPage : Page
    {
        public SQLFormatterViewModel ViewModel { get; }

        public SQLFormatterPage()
        {
            ViewModel = App.GetService<SQLFormatterViewModel>();
            InitializeComponent();
        }

        public string FormatSQL(string inputSql)
        {
            string formattedSQL = Formatter.Format(inputSql);
            return formattedSQL;
        }

        public void SQL_Changed(object sender, RoutedEventArgs e)
        {
            string inputSql = plainBox.Text;

            if (string.IsNullOrWhiteSpace(inputSql))
            {
                formattedBox.Text = "";
                return;
            }

            try
            {
                string formattedSQL = FormatSQL(inputSql);
                formattedBox.Text = formattedSQL;
            }
            catch (Exception ex)
            {
                formattedBox.Text = ex.Message;
            }

        }
    }
}
