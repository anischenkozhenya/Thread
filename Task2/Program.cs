using System;
using System.IO;
using System.Threading;
using System.Diagnostics;
//Создайте консольное приложение, которое в различных потоках сможет получить доступ к 2-м
//файлам.Считайте из этих файлов содержимое и попытайтесь записать полученную
//информацию в третий файл. Чтение/запись должны осуществляться одновременно в каждом
//из дочерних потоков.Используйте блокировку потоков для того, чтобы добиться корректной
//записи в конечный файл.

namespace Task2
{
    class Program
    {
        static object obj = new object();
        static StreamReader stream1 = File.OpenText(@"..\..\File1.txt");
        static StreamReader stream2 = File.OpenText(@"..\..\File2.txt");
        static StreamWriter stream3 = File.CreateText(@"..\..\File3.txt");

        static public void ReadMethod()
        {
            string str = stream1.ReadToEnd();
            lock (obj)
            {
                stream3.Write(str+"\n");
            }
        }
        static public void ReadMethod2()
        {
            string str = stream2.ReadToEnd();
            lock (obj)
            {
                stream3.Write(str + "\n");
            }
        }
        static void Main(string[] args)
        {
            Process.Start("explorer.exe",@"..\..\");
            Thread[] threads = new Thread[] { new Thread(ReadMethod), new Thread(ReadMethod2)};
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Start();
            }
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }
            stream1.Close();
            stream2.Close();
            stream3.Close();
            Console.WriteLine("Для выхода нажмите любую кнопку...");
            Console.ReadKey();
        }
    }
}
