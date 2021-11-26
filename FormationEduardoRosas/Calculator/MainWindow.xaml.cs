using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string result;
        private string lastResult;
        private string operation;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void acButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }

        private void negativeButton_Click(object sender, RoutedEventArgs e)
        {
            result = resultLabel.Content.ToString();

            if (result[0] == '-') result = result.Substring(1);
            else result = $"-{result}";

            resultLabel.Content = result;
        }

        private void percentButton_Click(object sender, RoutedEventArgs e)
        {
            result = resultLabel.Content.ToString();

            if (decimal.TryParse(result, out decimal resultValue))
            {
                resultValue /= 100.0m;
                result = resultValue.ToString();
            }

            resultLabel.Content = result;
        }



        private void equalsButton_Click(object sender, RoutedEventArgs e)
        {
            result = resultLabel.Content.ToString();

            if (decimal.TryParse(result, out decimal resultValue) && decimal.TryParse(lastResult, out decimal lastResultValue))
            {
                switch (operation)
                {
                    case "divide":
                        resultValue = lastResultValue / resultValue;
                        lastResultValue = 0.0m;
                        break;
                    case "multiply":
                        resultValue = lastResultValue * resultValue;
                        lastResultValue = 0.0m;
                        break;
                    case "substract":
                        resultValue = lastResultValue - resultValue;
                        lastResultValue = 0.0m;
                        break;
                    case "add":
                        resultValue = lastResultValue + resultValue;
                        lastResultValue = 0.0m;
                        break;
                    default:
                        break;
                }

                result = resultValue.ToString();
                lastResult = lastResultValue.ToString();
            }

            resultLabel.Content = result;
        }

        private void dotButton_Click(object sender, RoutedEventArgs e)
        {
            result = resultLabel.Content.ToString();

            if (!result.Contains(",")) result += ",";

            resultLabel.Content = result;
        }

        private void minusButton_Click(object sender, RoutedEventArgs e)
        {
            result = resultLabel.Content.ToString();
            lastResult = $"{result}";
            result = "0";
            operation = "substract";

            resultLabel.Content = result;
        }

        private void plusButton_Click(object sender, RoutedEventArgs e)
        {
            result = resultLabel.Content.ToString();
            lastResult = $"{result}";
            result = "0";
            operation = "add";

            resultLabel.Content = result;
        }

        private void divideButton_Click(object sender, RoutedEventArgs e)
        {
            result = resultLabel.Content.ToString();
            lastResult = $"{result}";
            result = "0";
            operation = "divide";

            resultLabel.Content = result;
        }

        private void multiplyButton_Click(object sender, RoutedEventArgs e)
        {
            result = resultLabel.Content.ToString();
            lastResult = $"{result}";
            result = "0";
            operation = "multiply";

            resultLabel.Content = result;
        }

        private void zeroButton_Click(object sender, RoutedEventArgs e)
        {
            result = resultLabel.Content.ToString();

            if (result != "0") result += "0";

            resultLabel.Content = result;
        }

        private void sevenButton_Click(object sender, RoutedEventArgs e)
        {
            result = resultLabel.Content.ToString();

            if (result == "-0") result = "-7";
            else if (result != "0") result += "7";
            else result = "7";

            resultLabel.Content = result;
        }

        private void threeButton_Click(object sender, RoutedEventArgs e)
        {
            result = resultLabel.Content.ToString();

            if (result == "-0") result = "-3";
            else if (result != "0") result += "3";
            else result = "3";

            resultLabel.Content = result;
        }

        private void twoButton_Click(object sender, RoutedEventArgs e)
        {
            result = resultLabel.Content.ToString();

            if (result == "-0") result = "-2";
            else if (result != "0") result += "2";
            else result = "2";

            resultLabel.Content = result;
        }

        private void oneButton_Click(object sender, RoutedEventArgs e)
        {
            result = resultLabel.Content.ToString();

            if (result == "-0") result = "-1";
            else if (result != "0") result += "1";
            else result = "1";

            resultLabel.Content = result;
        }


        private void sixButton_Click(object sender, RoutedEventArgs e)
        {
            result = resultLabel.Content.ToString();

            if (result == "-0") result = "-6";
            else if (result != "0") result += "6";
            else result = "6";

            resultLabel.Content = result;
        }

        private void fiveButton_Click(object sender, RoutedEventArgs e)
        {
            result = resultLabel.Content.ToString();

            if (result == "-0") result = "-5";
            else if (result != "0") result += "5";
            else result = "5";

            resultLabel.Content = result;
        }

        private void fourButton_Click(object sender, RoutedEventArgs e)
        {
            result = resultLabel.Content.ToString();

            if (result == "-0") result = "-4";
            else if (result != "0") result += "4";
            else result = "4";

            resultLabel.Content = result;
        }

        private void nineButton_Click(object sender, RoutedEventArgs e)
        {
            result = resultLabel.Content.ToString();

            if (result == "-0") result = "-9";
            else if (result != "0") result += "9";
            else result = "9";

            resultLabel.Content = result;
        }

        private void eightButton_Click(object sender, RoutedEventArgs e)
        {
            result = resultLabel.Content.ToString();

            if (result == "-0") result = "-8";
            else if (result != "0") result += "8";
            else result = "8";

            resultLabel.Content = result;
        }
    }
}
