using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//Используя конструкции блокировки, создайте метод, который будет в цикле for (допустим, на 10
//итераций) увеличивать счетчик на единицу и выводить на экран счетчик и текущий поток.
//Метод запускается в трех потоках. Каждый поток должен выполниться поочередно, т.е.в
//результате на экран должны выводиться числа (значения счетчика) с 1 до 30 по порядку, а не в
//произвольном порядке.

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Основной поток вытолняется в " + Thread.CurrentThread.ManagedThreadId + " потоке");
            Thread tread1 = new Thread(MyClass.WorkMethod);
            Thread tread2 = new Thread(MyClass.WorkMethod);
            Thread tread3 = new Thread(MyClass.WorkMethod);
            tread1.Start();
            //1.Дождаться окнчания работы
            tread1.Join();
            tread2.Start();
            //1.Дождаться окнчания работы
            tread2.Join();
            tread3.Start();
            //1.Дождаться окнчания работы
            tread3.Join();
            Console.WriteLine("Для выхода нажмите любую кнопку...");
            Console.ReadKey();
        }
    }
}
