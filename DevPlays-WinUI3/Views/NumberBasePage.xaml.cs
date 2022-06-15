using DevPlays_WinUI3.ViewModels;
using System;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;

namespace DevPlays_WinUI3.Views
{
    public sealed partial class NumberBasePage : Page
    {
        public int NumberBinary { get; set; }
        public NumberBasePage()
        {
            InitializeComponent();

        }

        private bool IsBinary(string input)
        {
            foreach (char c in input)
            {
                if (c != '0' && c != '1')
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsDecimal(string input)
        {
            foreach (char c in input)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }
            return true;
        }
        
        private bool IsOctal(string input)
        {
            foreach (char c in input)
            {
                if (c < '0' || c > '7')
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsHex(string input)
        {
            foreach (char c in input)
            {
                if (c < '0' || c > '9')
                {
                    if (c < 'A' || c > 'F')
                    {
                        if (c < 'a' || c > 'f')
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private bool isEmpty(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return true;
            }
            return false;
        }

        private void Binary_Changed(object sender, TextChangedEventArgs e)
        {
            string Binary = binaryTextBox.Text;

            if (isEmpty(Binary))
            {
                return;
            }

            DetachEvent(0);

            try
            {
                if (IsBinary(Binary))
                {
                     NumberBinary = Convert.ToInt32(Binary, 2);
                    decimalTextBox.Text = Convert.ToString(NumberBinary, 10);
                    hexTextBox.Text = Convert.ToString(NumberBinary, 16);
                    octalTextBox.Text = Convert.ToString(NumberBinary, 8);
                }
                else
                {
                    decimalTextBox.Text = "";
                    hexTextBox.Text = "";
                    octalTextBox.Text = "";
                }

            }
            catch (Exception ex)
            {
                decimalTextBox.Text = ex.Message;
                hexTextBox.Text = ex.Message;
                octalTextBox.Text = ex.Message;
            }
            AttachEvent(0);
        }

        private void Decimal_Changed(object sender, TextChangedEventArgs e)
        {

            string Decimal = decimalTextBox.Text;

            if (isEmpty(Decimal))
            {
                return;
            }

            DetachEvent(2);
            try
            {
                if (IsDecimal(Decimal))
                {
                    NumberBinary = Convert.ToInt32(Decimal);
                    binaryTextBox.Text = Convert.ToString(NumberBinary, 2);
                    hexTextBox.Text = Convert.ToString(NumberBinary, 16);
                    octalTextBox.Text = Convert.ToString(NumberBinary, 8);
                }
                else
                {
                    binaryTextBox.Text = "";
                    hexTextBox.Text = "";
                    octalTextBox.Text = "";
                }
            }
            catch (Exception ex)
            {
                binaryTextBox.Text = ex.Message;
                hexTextBox.Text = ex.Message;
                octalTextBox.Text = ex.Message;
            }
            AttachEvent(2);
        }
        private void Octal_Changed(object sender, TextChangedEventArgs e)
        {
            string Octal = octalTextBox.Text;

            if (isEmpty(Octal))
            {
                return;
            }

            DetachEvent(1);
            try
            {
                if (IsOctal(Octal))
                {
                    NumberBinary = Convert.ToInt32(Octal, 8);
                    binaryTextBox.Text = Convert.ToString(NumberBinary, 2);
                    decimalTextBox.Text = Convert.ToString(NumberBinary);
                    hexTextBox.Text = Convert.ToString(NumberBinary, 16);
                }
                else
                {
                    binaryTextBox.Text = "";
                    decimalTextBox.Text = "";
                    hexTextBox.Text = "";
                }
            }
            catch (Exception ex)
            {
                binaryTextBox.Text = ex.Message;
                hexTextBox.Text = ex.Message;
                decimalTextBox.Text = ex.Message;
            }
            AttachEvent(1);
        }

        private void Hex_Changed(object sender, TextChangedEventArgs e)
        {
            string Hex = hexTextBox.Text;

            if (isEmpty(Hex))
            {
                return;
            }

            DetachEvent(3);
            try
            {
                if (IsHex(Hex))
                {
                    NumberBinary = Convert.ToInt32(Hex, 16);
                    binaryTextBox.Text = Convert.ToString(NumberBinary, 2);
                    decimalTextBox.Text = Convert.ToString(NumberBinary);
                    octalTextBox.Text = Convert.ToString(NumberBinary, 8);
                }
                else
                {
                    binaryTextBox.Text = "";
                    decimalTextBox.Text = "";
                    octalTextBox.Text = "";
                }
            }
            catch (Exception ex)
            {
                binaryTextBox.Text = ex.Message;
                decimalTextBox.Text = ex.Message;
                octalTextBox.Text = ex.Message;
            }
            AttachEvent(3);
        }

        public void DetachEvent(int selection)
        {
            switch (selection)
            {
                case 0:
                    octalTextBox.TextChanged -= Octal_Changed;
                    decimalTextBox.TextChanged -= Decimal_Changed;
                    hexTextBox.TextChanged -= Hex_Changed;
                    break;
                case 1:
                    binaryTextBox.TextChanged -= Binary_Changed;
                    decimalTextBox.TextChanged -= Decimal_Changed;
                    hexTextBox.TextChanged -= Hex_Changed;
                    break;
                case 2:
                    binaryTextBox.TextChanged -= Binary_Changed;
                    octalTextBox.TextChanged -= Octal_Changed;
                    hexTextBox.TextChanged -= Hex_Changed;
                    break;
                case 3:
                    binaryTextBox.TextChanged -= Binary_Changed;
                    octalTextBox.TextChanged -= Octal_Changed;
                    decimalTextBox.TextChanged -= Decimal_Changed;
                    break;

            }

        }

        public void AttachEvent(int selection)
        {
            switch (selection)
            {
                case 0:
                    octalTextBox.TextChanged += Octal_Changed;
                    decimalTextBox.TextChanged += Decimal_Changed;
                    hexTextBox.TextChanged += Hex_Changed;
                    break;
                case 1:
                    binaryTextBox.TextChanged += Binary_Changed;
                    decimalTextBox.TextChanged += Decimal_Changed;
                    hexTextBox.TextChanged += Hex_Changed;
                    break;
                case 2:
                    binaryTextBox.TextChanged += Binary_Changed;
                    octalTextBox.TextChanged += Octal_Changed;
                    hexTextBox.TextChanged += Hex_Changed;
                    break;
                case 3:
                    binaryTextBox.TextChanged += Binary_Changed;
                    octalTextBox.TextChanged += Octal_Changed;
                    decimalTextBox.TextChanged += Decimal_Changed;
                    break;

            }
        }
    }
}
