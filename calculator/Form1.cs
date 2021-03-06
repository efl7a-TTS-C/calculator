﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        string input;
        string num1;
        string num2;
        string operation;
        bool toCalculate = false;
        Calculator calculator = new Calculator();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            resetForm();
        }
        
        private void resetForm()
        {
            num1 = String.Empty;
            num2 = String.Empty;
            operation = String.Empty;
            input = String.Empty;
        }
        private void display(string textToDisplay)
        {
            if(textToDisplay.Length < 15) 
            {
                displayBox.Text = textToDisplay;
            } else 
            {
                string text = Convert.ToDouble(textToDisplay).ToString("G10");
                displayBox.Text = text;

            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(num2))
            {
                num2 = String.Empty;
                display(num1);
            } else
            {
                resetForm();
                display(input);
            }
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
            if (toCalculate)
            {
                num2 = input;
                handleComputation();
            }
            toCalculate = false;
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
            if (!toCalculate && String.IsNullOrEmpty(num1))
            {
                num1 = input;
                display(num1);
                toCalculate = true;
                input = String.Empty;

            }
            else if (toCalculate)
            {
                if (String.IsNullOrEmpty(input))
                {
                    num2 = num1;
                }
                else
                {
                    num2 = input;
                }
                handleComputation();
            } else
            {
                toCalculate = true;
            }
            operation = current.Name;
        }

        private void handleComputation()
        {
            string result = calculator.compute(num1, num2, operation);
            if(String.IsNullOrEmpty(result))
            {
                display("error");
                resetForm();
            } 
            else
            {
                resetForm();
                num1 = result;
                display(num1);
            }
        }
    }
}
