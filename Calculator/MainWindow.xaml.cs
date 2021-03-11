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
        double lastNumber, result;
        SelectedOperator selectedOperator;

        public MainWindow()
        {
            InitializeComponent();

            // resultLabel.Content = "14321";

            acButton.Click += AcButton_Click;
            negativeButton.Click += NegativeButton_Click;
            percentageButton.Click += PercentageButton_Click;
            equalsButton.Click += EqualsButton_Click;
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            // throw new NotImplementedException();
            double newNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
            {
                switch(selectedOperator)
                {
                    case SelectedOperator.Division:
                        result = SimpleMath.Division(lastNumber, newNumber);
                        break;

                    case SelectedOperator.Product:
                        result = SimpleMath.Product(lastNumber, newNumber);
                        break;

                    case SelectedOperator.Addition:
                        result = SimpleMath.Addition(lastNumber, newNumber);
                        break;

                    case SelectedOperator.Subtraction:
                        result = SimpleMath.Subtraction(lastNumber, newNumber);
                        break;
                }
            }

            resultLabel.Content = result.ToString();
        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            // throw new NotImplementedException();
            double tempNumber;
            if(double.TryParse(resultLabel.Content.ToString(), out tempNumber))
            {
                tempNumber /= 100;
                if (lastNumber != 0)
                {
                    tempNumber *= lastNumber;
                }
                resultLabel.Content = tempNumber.ToString();
            }
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            // throw new NotImplementedException();
            if(double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = (-1) * lastNumber;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            // throw new NotImplementedException();
            resultLabel.Content = "0";
            result = 0;
            lastNumber = 0;
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = "0";
            }

            if (sender == divisionButton)
                selectedOperator = SelectedOperator.Division;
            if (sender == productButton)
                selectedOperator = SelectedOperator.Product;
            if (sender == additionButton)
                selectedOperator = SelectedOperator.Addition;
            if (sender == subtractButton)
                selectedOperator = SelectedOperator.Subtraction;
        }

        private void decimalButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString().Contains("."))
            {
                // Do nothing
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}.";
            }
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            /*
            int selectedValue = 0;

            if (sender == zeroButton)
            {
                selectedValue = 0;
            }
            if (sender == oneButton)
            {
                selectedValue = 1;
            }
            if (sender == twoButton)
            {
                selectedValue = 2;
            }
            if (sender == threeButton)
            {
                selectedValue = 3;
            }
            if (sender == fourButton)
            {
                selectedValue = 4;
            }
            if (sender == fiveButton)
            {
                selectedValue = 5;
            }
            if (sender == sixButton)
            {
                selectedValue = 6;
            }
            if (sender == sevenButton)
            {
                selectedValue = 7;
            }
            if (sender == eightButton)
            {
                selectedValue = 8;
            }
            if (sender == nineButton)
            {
                selectedValue = 9;
            } */

            int selectedValue = int.Parse((sender as Button).Content.ToString());

            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = $"{selectedValue}";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
            }
        }
    }

    public enum SelectedOperator
    {
        Addition,
        Subtraction,
        Product,
        Division
    }

    public class SimpleMath
    {
        public static double Addition(double n1, double n2)
        {
            return n1 + n2;
        }

        public static double Subtraction(double n1, double n2)
        {
            return n1 - n2;
        }

        public static double Product(double n1, double n2)
        {
            return n1 * n2;
        }

        public static double Division(double n1, double n2)
        {
            if (n2 == 0)
            {
                MessageBox.Show("Division by zero not supported", "Wrong Operation", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }

            return n1 / n2;
        }
    }
}
