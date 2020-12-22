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

namespace MyPerfectWPFCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonOne_Click(object sender, RoutedEventArgs e)
        {
            CurrentNum.Text += "1";
        }

        private void ButtonZero_Click(object sender, RoutedEventArgs e)
        {
            CurrentNum.Text += "0";
        }

        private void ButtonTwo_Click(object sender, RoutedEventArgs e)
        {
            CurrentNum.Text += "2";
        }

        private void ButtonThree_Click(object sender, RoutedEventArgs e)
        {
            CurrentNum.Text += "3";
        }

        private void ButtonFour_Click(object sender, RoutedEventArgs e)
        {
            CurrentNum.Text += "4";
        }

        private void ButtonFive_Click(object sender, RoutedEventArgs e)
        {
            CurrentNum.Text += "5";
        }

        private void ButtonSix_Click(object sender, RoutedEventArgs e)
        {
            CurrentNum.Text += "6";
        }

        private void ButtonSeven_Click(object sender, RoutedEventArgs e)
        {
            CurrentNum.Text += "7";
        }

        private void ButtonEight_Click(object sender, RoutedEventArgs e)
        {
            CurrentNum.Text += "8";
        }

        private void ButtonNine_Click(object sender, RoutedEventArgs e)
        {
            CurrentNum.Text += "9";
        }

        private void ButtonPlus_Click(object sender, RoutedEventArgs e)
        {
            Operator.Text += "+";
            PreviousNum.Text += CurrentNum.Text;
            CurrentNum.Text = "";
        }

        private void ButtonMinus_Click(object sender, RoutedEventArgs e)
        {
            Operator.Text += "-";
            PreviousNum.Text += CurrentNum.Text;
            CurrentNum.Text = "";
        }

        private void ButtonEquals_Click(object sender, RoutedEventArgs e)
        {
            int firstNum = int.Parse(PreviousNum.Text);
            int secondNum = int.Parse(CurrentNum.Text);
            string op = Operator.Text;
            if (op == "+")
            {
                firstNum += secondNum;
            }
            else if(op == "-")
            {
                firstNum -= secondNum;
            }
            else if (op == "*")
            {
                firstNum *= secondNum;
            }
            else if (op == "/")
            {
                firstNum /= secondNum;
            }
            CurrentNum.Text = firstNum + "";
            PreviousNum.Text = "";
            Operator.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Operator.Text += "*";
            PreviousNum.Text += CurrentNum.Text;
            CurrentNum.Text = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Operator.Text += "/";
            PreviousNum.Text += CurrentNum.Text;
            CurrentNum.Text = "";
        }
    }
}
