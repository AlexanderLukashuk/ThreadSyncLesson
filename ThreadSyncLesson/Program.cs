using System;
using System.Threading;

namespace ThreadSyncLesson
{
    class Program
    {
        private static object lockObject = new object();
        private static int number = 0;

        static void Main(string[] args)
        {
            Account account = new Account();

            //for (int i = 0; i < 10; i++)
            //{
            //Thread thread = new Thread(IncrementNumber);
            //thread.IsBackground = false;
            //thread.Start();
            Thread thread = new Thread(account.ProcessMoney);
            thread.IsBackground = false;
            thread.Start(200);

            Thread thread2 = new Thread(account.ProcessMoney);
            thread2.IsBackground = false;
            thread2.Start(-100);

            Thread thread3 = new Thread(account.ProcessMoney);
            thread3.IsBackground = false;
            thread3.Start(-50);

            Thread thread4 = new Thread(account.ProcessMoney);
            thread4.IsBackground = false;
            thread4.Start(100);

            Thread thread5 = new Thread(account.ProcessMoney);
            thread5.IsBackground = false;
            thread5.Start(50);

            Thread thread6 = new Thread(account.ProcessMoney);
            thread6.IsBackground = false;
            thread6.Start(200);
            //}

            TextBox textBox = GetTextBoxFromUIByName("nameTextBox");
            new Thread(() =>
            {
                textBox.Text = "Привет из потока";
            });

            /*
             * 1) Не скомпилируется
             * 2) Текст отобразится на экране
             * 3) Будет ошибка - такого элемента не существует, так как она не обработана
             * 4) Будет выдано исключение при попытке обратиться к UI элементу из другого потока
             * 
             */
        }

        public static void IncrementNumber()
        {
            /*
             * Человек оплачивает электроэнергию через счет банка
             * 1) Снять деньги с текущего счета человека
             * 2) Осуществить перевод на транзитный счет
             * 3) Осуществить перевод с транзитного счета
             * 4) Зачислисть деньги на счет компании электрокомпании
             * 
             * 
             * Пополнение и снятие со счета денег одного пользователя:
             * 
             * В течении короткого времени пользователю поступают деньги на счет, а также деньги со счета снимаются
             * 
             * 100 операций (+200, -100, -50, -200, +500, -700)
             * 
             * Общая сумма на счету пользователя = 1000$;
             * Общая переменная для сумм пополнения и снятия Sum = 0;
             * 
             * 1 поток успевает сделать Sum = 200 и все
             * 2 поток успевает сделать Sum = -100 и снять со счета эти деньги. Итого на счету пользователя = 900; и обнуляет Sum
             * 3 поток успевает сделать Sum = 50 и все
             * 1 поток делает вычисление Total(900) + Sum(-50) итого -850. Обнуляет Sum
             * 3 поток проводит вычисления = 850. Обнуляет переменную
             * 
             */
            lock (lockObject)
            {
                //Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] - number = {number}");
                number = 1;

                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] - number = {number}");
                    Thread.Sleep(500);

                    Interlocked.Increment(ref number);
                    //number++;
                }
            }
        }
    }
}
