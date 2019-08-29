using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1
{
    class MyClass
    {
        //Элемент блокировки не структурный тип
        public static readonly object obj = new object();
        //Элемент блокировки структурный тип
        private static int c = 0;

        static public void WorkMethod()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " поток создан");
            for (int i = 0; i < 10; i++)
            {
                //4.
                lock (obj)
                {
                    c++;
                }
                //3.
                ////try
                //{
                //    Monitor.Enter(obj);
                //    c++;
                //}
                //finally
                //{
                //    Monitor.Exit(obj);

                //}
                //2.interlock
                //Interlocked.Increment(ref c);
                //1.
                //c++;                   
                Console.WriteLine("имя потока=" + Thread.CurrentThread.ManagedThreadId + "-значение=" + c.ToString());
            }
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " поток завершился");

        }
    }
}
