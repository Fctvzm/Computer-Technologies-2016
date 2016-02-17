using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2._4
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo d = new DirectoryInfo(@"C:\Users\admin\Documents\Programming languages\far2.0");
            DirectoryInfo[] directories = d.GetDirectories();
            FileInfo[] files = d.GetFiles();
            int index = 0;
            
            bool x = false;
            while (true)
            {
                if (x == false)
                {
                    for (int i = 0; i < directories.Length+files.Length; i++)
                    {
                        if (index == i)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        if (i < directories.Length)
                            Console.WriteLine(directories[i].Name);
                        else
                            Console.WriteLine(files[i-directories.Length].Name);
                    }
                }
                ConsoleKeyInfo button = Console.ReadKey();
                if (button.Key == ConsoleKey.UpArrow)
                {
                    if (index > 0)
                        index--;
                }
                if (button.Key == ConsoleKey.DownArrow)
                {
                    if (index < directories.Length+files.Length - 1)
                        index++;
                }
                if (button.Key == ConsoleKey.Enter)
                {
                    if (index < directories.Length)
                    {
                        FileInfo[] f = directories[index].GetFiles();
                        foreach(FileInfo y in f)
                            Console.WriteLine(y.Name);
                        x = true;
                    }
                    else {
                        FileStream f = new FileStream(files[index-directories.Length].FullName, FileMode.OpenOrCreate, FileAccess.Read);
                        StreamReader sr = new StreamReader(f);
                        Console.Write(sr.ReadToEnd());
                        sr.Close();
                        f.Close();
                        x = true;
                    }
                }
                if (button.Key == ConsoleKey.Escape)
                    x = false;


                if (x == false)
                    Console.Clear();
            }
        }
    }
}
