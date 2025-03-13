using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace calcu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class calculator : ContentPage
    {
        string currentNumber = string.Empty;
        double result = 0;
        string currentOperator = string.Empty;
        public calculator()
        {
            InitializeComponent();
        }

        void OnclickedButton_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentNumber += button.Text;
            resultLabel.Text = currentNumber;

        }

        private void OnOperationButton_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentOperator = button.Text;
            if(double.TryParse(currentNumber, out double number))
            {
                result = number;
                currentNumber = string.Empty;
            }
        }

        void ClearButton_Clicked(object sender, EventArgs e)
        {
            currentNumber = string.Empty;
            result = 0;
            currentOperator = string.Empty;
            resultLabel.Text = "0";
        }

         void EqualButton_Clicked(object sender, EventArgs e)
        {
            if(double.TryParse(currentNumber, out double number))
            {
                switch (currentOperator)
                {
                    case "+":
                        result += number;
                        break;
                    case "-":
                        result -= number;
                        break;
                    case "*":
                        result *= number;
                        break;
                    case "/":
                        if (number == 0)
                        {
                            resultLabel.Text = "Error";
                            currentNumber = string.Empty;
                            currentOperator = string.Empty;
                            return;
                        }
                           

                        else
                            result /= number;
                        break;
                }
                resultLabel.Text = result.ToString();
                currentNumber = result.ToString();
            }
        }
    }
}