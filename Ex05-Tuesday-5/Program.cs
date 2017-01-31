using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Ex05_Tuesday_5
{
    class Program
    {
        private static int _counter = 0;
        private static Object o = _counter;
        static void Main(string[] args)
        {
            Thread myThread1 = new Thread(new ThreadStart(Thread1));
            Thread myThread2 = new Thread(new ThreadStart(Thread2));
            myThread1.Start();
            myThread2.Start();
            Thread.Sleep(10000);
        }

        static void Thread1()
        {
            while (true)
            {
                Monitor.Enter(o);
                try
                {
                    _counter = _counter + 2;
                }
                finally
                {
                    Console.WriteLine(_counter);
                    Monitor.Exit(o);
                    Thread.Sleep(1000);
                }
            }
        }

        static void Thread2()
        {
            while (true)
            {
                Monitor.Enter(o);
                try
                {
                    _counter = _counter - 1;

                }
                finally
                {
                    Console.WriteLine(_counter);
                    Monitor.Exit(o);
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
