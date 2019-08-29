using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    static class MyClass
    {
        static object obj = new object();

        static StreamReader stream1 = File.OpenText(@"C:\Users\Anischenko\Desktop\Потоки\Задача1\Задача2\File1.txt");
        static StreamReader stream2 = File.OpenText(@"C:\Users\Anischenko\Desktop\Потоки\Задача1\Задача2\File2.txt");
        static StreamWriter stream3 = File.CreateText(@"C:\Users\Anischenko\Desktop\Потоки\Задача1\Задача2\File3.txt");

        static public void ReadMethod()
        {
            string str = stream1.ReadToEnd();
            lock (obj)
            {
                stream3.Write(str);
            }
        }
        static public void ReadMethod2()
        {
            string str = stream2.ReadToEnd();
            lock (obj)
            {
                stream3.Write(str);
            }
        }
    }
}
