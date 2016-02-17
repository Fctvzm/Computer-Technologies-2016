using System;
using System.IO;
using System.Collections.Generic;
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
            try {
                FileStream input = new FileStream(@"C:\Users\admin\Documents\input.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                FileStream output = new FileStream(@"C:\Users\admin\Documents\output.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

                StreamReader sr = new StreamReader(input);
                StreamWriter sw = new StreamWriter(output);

                string s = sr.ReadLine();
                sr.Close();
                input.Close();

                string[] str = s.Split(' ');
                int max = 0; int min = 9999;
                foreach (string i in str)
                {
                    if (int.Parse(i) > max)
                        max = int.Parse(i);
                    if (int.Parse(i) < min)
                        min = int.Parse(i);
                }

                sw.WriteLine("minimum number is {0}", min);
                sw.WriteLine("maximum number is {0}", max);


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
