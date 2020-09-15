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
            double result;

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
                    return null;
            }

            if(Double.IsNaN(result) || Double.IsInfinity(result))
            {
                return null;
            } 
            else
            {
                return result.ToString();
            }

        }
    }
}
