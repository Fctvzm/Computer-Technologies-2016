using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string abc = @"C:\Users\admin\Documents\Computer fundamentals";
            stackFunction(abc);
            Console.ReadKey();
        } 

        public static void stackFunction (string road) {
            Stack<string> s = new Stack<string>(20);
            s.Push(road);
            while (s.Count > 0)
            {
                string currentDir = s.Pop();
                try {
                    DirectoryInfo directory = new DirectoryInfo(currentDir);
                    Console.WriteLine(directory.Name);
                    FileInfo [] files = directory.GetFiles();
                    foreach (FileInfo file in files)
                        Console.WriteLine("File Name: {0}, Size: {1}", file.Name, file.Length);
                    string[] Dirs = Directory.GetDirectories(currentDir);
                    for (int i=Dirs.Length-1; i>=0; i--)
                        s.Push(Dirs[i]);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }
    }
}
