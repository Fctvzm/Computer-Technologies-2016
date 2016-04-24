using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Calc
    {
        public double first;
        public double second;
        public double result;
        public string operation;

        public void Calculate ()
        {
            if (operation == "+")
                result = first + second;
            else if (operation == "-")
                result = first - second;
            else if (operation == "*")
                result = first * second;
            else if (operation == "/")
                result = first / second;
            else if (operation == "x^y")
            {
                result = first;
                for (int i = 2; i <= second; i++)
                    result *= first;
            }
            else if (operation == "%")
                result = (first * second) / 100;
            
        }
        public double Result
        {
            get { return result; }
            set { result = value; }
        }
    }
}
