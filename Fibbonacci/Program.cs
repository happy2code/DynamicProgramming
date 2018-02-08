using System;
using System.Diagnostics;

namespace Fibbonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            //sw.Start();
            //Console.WriteLine("40th  Fibbonaci number is {0}", Implementation.Fib1(40));
            //sw.Stop();
            //Console.WriteLine("Time Taken = {0} ticks", sw.ElapsedTicks);

            //Console.WriteLine("****************************************************");

            sw.Restart();
            Console.WriteLine("40th  Fibbonaci number is {0}", Implementation.Fib2(10));
            sw.Stop();
            Console.WriteLine("Time Taken = {0} ticks", sw.ElapsedTicks);

        }
    }
}
