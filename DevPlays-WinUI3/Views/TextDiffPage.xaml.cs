using DevPlays_WinUI3.ViewModels;

using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using System;
using DiffPlex.DiffBuilder;
using System.ComponentModel;
using System.Diagnostics;
using DiffPlex.Model;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Media;
using DiffPlex.DiffBuilder.Model;
using Microsoft.UI;

using DiffPlex.Wpf.Controls;
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
            // Clear RichEditBox 
            diffTextBox.SelectAll();

            diffTextBox.Blocks.Clear();
            int _line = 0;

            foreach (var line in diff.Lines)
            {

                Paragraph new_paragraph = new Paragraph();
                Run run = new Run();

                if (line.Type == ChangeType.Inserted)
                {
                    // Show line number in green
                    run.Text = $"+ " + line.Text;
                    run.Foreground = new SolidColorBrush(Colors.Green);
                    new_paragraph.Inlines.Add(run);
                }
                else if (line.Type == ChangeType.Deleted)
                {
                    run.Text = $"- " + line.Text;
                    run.Foreground = new SolidColorBrush(Colors.Red);
                    new_paragraph.Inlines.Add(run);
                }
                else
                {
                    run.Text = $" " + line.Text;
                    run.Foreground = new SolidColorBrush(Colors.White);
                    new_paragraph.Inlines.Add(run);
                }

                diffTextBox.Blocks.Add(new_paragraph);
                _line++;
            }
        }

        public void New_Changed(object sender, RoutedEventArgs e)
        {
            OldText = oldTextBox.Text;
            NewText = newTextBox.Text;

            var diff = InlineDiffBuilder.Diff(OldText, NewText);
            // Clear RichEditBox named diffTextBox
            diffTextBox.SelectAll();

            diffTextBox.Blocks.Clear();

            int _line = 0;

            foreach (var line in diff.Lines)
            {

                Paragraph new_paragraph = new Paragraph();
                Run run = new Run();

                if (line.Type == ChangeType.Inserted)
                {
                    // Show line number in green
                    run.Text = $"+ " + line.Text;
                    run.Foreground = new SolidColorBrush(Colors.Green);
                    new_paragraph.Inlines.Add(run);
                }
                else if (line.Type == ChangeType.Deleted)
                {
                    run.Text = $"- " + line.Text;
                    run.Foreground = new SolidColorBrush(Colors.Red);
                    new_paragraph.Inlines.Add(run);
                }
                else
                {
                    run.Text = $" " + line.Text;
                    run.Foreground = new SolidColorBrush(Colors.White);
                    new_paragraph.Inlines.Add(run);
                }
                diffTextBox.Blocks.Add(new_paragraph);
                _line++;
            }
        }
    }
}
