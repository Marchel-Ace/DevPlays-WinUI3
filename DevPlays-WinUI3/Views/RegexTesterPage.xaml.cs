using DevPlays_WinUI3.ViewModels;
using System;
using System.Text.RegularExpressions;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI;
using System.Diagnostics;
using Microsoft.UI.Xaml;
using Microsoft.UI.Text;

namespace DevPlays_WinUI3.Views
{
    public sealed partial class RegexTesterPage : Page
    {
        public RegexTesterViewModel ViewModel { get; }
        Regex regex;
        TextRange textRange;
        TextRange range;

        public RegexTesterPage()
        {
            ViewModel = App.GetService<RegexTesterViewModel>();
            InitializeComponent();
        }

        private void regexPattern_TextChanged(object sender, TextChangedEventArgs e)
        {
            regex = new Regex(regexPattern.Text);
        }
        private void RemoveHighlight()
        {
            regexText.TextChanged -= regexText_TextChanged;
            ITextRange documentRange = regexText.Document.GetRange(0, TextConstants.MaxUnitCount);
            SolidColorBrush defaultBackground = regexText.Background as SolidColorBrush;
            SolidColorBrush defaultForeground = regexText.Foreground as SolidColorBrush;

            documentRange.CharacterFormat.BackgroundColor = defaultBackground.Color;
            documentRange.CharacterFormat.ForegroundColor = defaultForeground.Color;
            regexText.TextChanged += regexText_TextChanged;
        }
        private void regexText_TextChanged(object sender, RoutedEventArgs e)
        {
            // Read the regexText value
            // Find all matches
            // Highlight the matches
            // Display the matches in RichTextBlock

            try
            {
                if (regex != null)
                {
                    string txt;
                    regexText.Document.GetText(TextGetOptions.UseCrlf, out txt);
                    RemoveHighlight();

                    MatchCollection matches = regex.Matches(txt);

                    regexText.TextChanged -= regexText_TextChanged;

                    foreach (Match match in matches)
                    {
                        int start = match.Index;
                        int length = match.Length;
                        ITextRange range = regexText.Document.GetRange(start, length);
                        range.CharacterFormat.BackgroundColor = Colors.Red;
                        range.CharacterFormat.ForegroundColor = Colors.White;
                    }
                    regexText.TextChanged += regexText_TextChanged;

                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
            }
        }
    }
}
