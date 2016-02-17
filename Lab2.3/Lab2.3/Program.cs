using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            findMinMax();
        }

        static void findMinMax()
        {
            try
            {
                FileStream input = new FileStream(@"C:\Users\admin\Documents\input.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                FileStream output = new FileStream(@"C:\Users\admin\Documents\output.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

                StreamReader sr = new StreamReader(input);
                StreamWriter sw = new StreamWriter(output);

                string s = sr.ReadLine();
                sr.Close();
                input.Close();

                string[] str = s.Split(' ');
                int min = int.Parse(str[0]); bool is_Prime = true;  
                foreach (string a in str)
                {
                    int x = int.Parse(a);
                    for (int i = 2; i*i <= x; i++) 
                    {
                        if (x % i == 0)
                            is_Prime = false;
                    }
                    if (is_Prime)
                    {
                        if (x < min)
                            min = x;
                    }
                }

                sw.WriteLine("minimum number is {0}", min);

                Console.ReadKey();
                sw.Close();
                output.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

