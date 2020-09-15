using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    class Calculator
    {
        public string compute(string num1, string num2, string operation)
        {
            double n1;
            double n2;

            try
            {
                n1 = Convert.ToDouble(num1);
                n2 = Convert.ToDouble(num2);
            }
            catch (FormatException e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return null;
            }

            switch (operation)
            {
                case "add":
                    return (n1 + n2).ToString();
                    
                case "subtract":
                    return (n1 - n2).ToString();

                case "multiply":
                    return (n1 * n2).ToString();

                case "divide":
                    return (n1 / n2).ToString();

                default:
                    return null;
            }
        }
    }
}
