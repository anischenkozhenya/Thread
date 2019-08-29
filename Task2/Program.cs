using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//Создайте консольное приложение, которое в различных потоках сможет получить доступ к 2-м
//файлам.Считайте из этих файлов содержимое и попытайтесь записать полученную
//информацию в третий файл. Чтение/запись должны осуществляться одновременно в каждом
//из дочерних потоков.Используйте блокировку потоков для того, чтобы добиться корректной
//записи в конечный файл.

namespace Task2
{
    class Program
    {     
        static void Main(string[] args)
        {
            Thread[] threads = new Thread[] { new Thread(MyClass.ReadMethod), new Thread(MyClass.ReadMethod2) };
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
        }
    }
}
