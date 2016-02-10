using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
            for (int i = a; i <= b; i++) {
                bool is_prime = true;
                for (int j = 2; j*j<=i; j++) {
                    if (i % j == 0)
                        is_prime = false;
                }
                if (is_prime) {
                    Console.WriteLine(i);
                }
            }
            Console.ReadKey();
        }
    }
}
