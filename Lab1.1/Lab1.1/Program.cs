using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1._1
{
    class Complex
    {
        public int a, b;
        public Complex(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public override string ToString()
        {
            return a + "/" + b;
        }

        public static Complex operator +(Complex c1, Complex c2)
        {
            Complex c3;
            if (c1.b == c2.b)
            {
                c3 = new Complex(c1.a + c2.a, c1.b);
            }
            else
            {
                int i = c1.b * c2.b;
                int j = c1.a * c2.b + c2.a * c1.b;
                int x = i;
                int y = j;

                while (x != 0 && y != 0)
                {
                    if (x > y)
                        x = x % y;
                    else
                        y = y % x;
                }
            
                int k = x + y;
                c3 = new Complex(j / k, i / k);
            }
        return c3;
    }
}
class Program
    {
        static void Main(string[] args) {
            int A, B, C, D;
            A = int.Parse(Console.ReadLine());
            B = int.Parse(Console.ReadLine());
            C = int.Parse(Console.ReadLine());
            D = int.Parse(Console.ReadLine());
            Complex c = new Complex(A, B);
            Complex d = new Complex(C, D);
            Complex w = c + d;
            Console.WriteLine(w);
            Console.ReadKey();
        }
    }
}




