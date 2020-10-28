using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadSyncLesson
{
    public class Account
    {
        //private AutoResetEvent autoReserEvent = new AutoResetEvent(false);
        //private object lockObject = new object();
        //private Mutex mutex = new Mutex();
        public int Total { get; set; } = 1000;
        public int Sum { get; set; }

        public void ProcessMoney(object sum)
        {
            //lock (lockObject)
            //{
            //    Sum = (int)sum;

            //    Thread.Sleep(1000); // имитация работы банка

            //    Console.WriteLine($"Ваш баланс составляет {Total += Sum}$");
            //}

            //try
            //{
            //    Monitor.Enter(lockObject);

            //    Sum = (int)sum;

            //    Thread.Sleep(1000); // имитация работы банка

            //    Console.WriteLine($"Ваш баланс составляет {Total += Sum}$");
            //}
            //finally
            //{
            //    Monitor.Exit(lockObject);
            //}

            //autoReserEvent.WaitOne();
            //Sum = (int)sum;

            //Thread.Sleep(1000); // имитация работы банка

            //Console.WriteLine($"Ваш баланс составляет {Total += Sum}$");

            //autoReserEvent.Set();

            //mutex.WaitOne();
            //Sum = (int)sum;

            //Thread.Sleep(1000); // имитация работы банка

            //Console.WriteLine($"Ваш баланс составляет {Total += Sum}$");

            //mutex.ReleaseMutex();
        }
    }
}
