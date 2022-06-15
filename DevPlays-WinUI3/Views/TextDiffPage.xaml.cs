using DevPlays_WinUI3.ViewModels;

using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using System;
using DiffPlex.DiffBuilder;
using System.ComponentModel;
using System.Diagnostics;
using DiffPlex.Model;
namespace DevPlays_WinUI3.Views
{
    public sealed partial class TextDiffPage : Page, INotifyPropertyChanged
    {
        public TextDiffViewModel ViewModel { get; }

        public TextDiffPage()
        {
            ViewModel = App.GetService<TextDiffViewModel>();
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;


        private string _oldtext;
        private string _newtext;

        public string OldText
        {
            get { return _oldtext; }
            set
            {
                if (string.Equals(value, OldText))
                    return;
                _oldtext = value;
                OnPropertyChanged(nameof(OldText));
                

            }
        }

        public string NewText
        {
            get { return _newtext; }
            set
            {
                if (string.Equals(value, NewText))
                    return;
                _newtext = value;
                OnPropertyChanged(nameof(NewText));
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Old_Changed(object sender, RoutedEventArgs e)
        {
            OldText = oldTextBox.Text;
            NewText = newTextBox.Text;

            var diff = InlineDiffBuilder.Diff(OldText, NewText);
            // Clear RichEditBox named diffTextBox
            diffTextBox.SelectAll();

            diffTextBox.Blocks.Clear();
            
            foreach (var line in diff.Lines)
            {

            }
        }

        public void New_Changed(object sender, RoutedEventArgs e)
        {
        }
    }
}
