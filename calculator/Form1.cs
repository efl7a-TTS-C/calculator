using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        string input = string.Empty;
        string num1 = string.Empty;
        string num2 = string.Empty;
        string operation = string.Empty;
        double result = 0.0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void display(string textToDisplay)
        {
            System.Diagnostics.Debug.WriteLine(textToDisplay.Length);
            if(textToDisplay.Length < 15) 
            {
                displayBox.Text = textToDisplay;
            } else 
            {
                string text = Convert.ToDouble(textToDisplay).ToString("G10");
                System.Diagnostics.Debug.WriteLine("This is after formatting: " + text);

                displayBox.Text = text;

            }
        }
       
        private void clear_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(num2))
            {
                num2 = String.Empty;
            } else
            {
                num1 = String.Empty;
            }
            input = String.Empty;
            display(input);
         }

        private void neg_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(input))
            {
                if (input.Substring(0, 1) == "-")
                {
                    input = input.Substring(1, input.Length);
                }
                else
                {
                    input = "-" + input;
                }
                display(input);
            }
        }

        private void percentage_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(input))
            {
                input = (Convert.ToDouble(input) * .01).ToString();
                display(input);
            }
        }

        private void equals_Click(object sender, EventArgs e)
        {
            num2 = input;
            handleComputation();
        }


        private void handleNumberClick(object sender, EventArgs e)
        {
            Button current = (Button) sender;
            if(current.Text == "." && input.Contains("."))
            {
                return;
            }
            input += current.Text;
            display(input);
        }

        private void handleOperationsClick(object sender, EventArgs e)
        {
            Button current = (Button)sender;
            if (String.IsNullOrEmpty(operation))
            {
                operation = current.Name;
                num1 = input;
                display(num1);
                input = String.Empty;

            } else
            {
                num2 = input;
                handleComputation();
                operation = current.Name;
            }
        }

        private void handleComputation()
        {
            double n1 = Convert.ToDouble(num1);
            double n2 = Convert.ToDouble(num2);
            Console.WriteLine(n1.ToString(), n2.ToString());
            switch(operation)
            {
                case "add":
                    result = n1 + n2;
                    break;
                case "subtract":
                    result = n1 - n2;
                    break;
                case "multiply":
                    result = n1 * n2;
                    break;
                case "divide":
                    result = n1 / n2;
                    break;
                default:
                    Console.WriteLine("an error has occurred.");
                    break;
            }
            Console.WriteLine(result);
            num1 = result.ToString();
            display(num1);
            input = String.Empty;
            num2 = String.Empty;
            operation = String.Empty;
        }
    }
}
