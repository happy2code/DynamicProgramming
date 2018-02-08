using System;
using System.Diagnostics;

namespace DroppingEggs
{
    class Program
    {
        static void Main(string[] args)
        {
            int eggs = 5;
            int floors = 35;
            EggDrop eggDrop = new EggDrop(eggs, floors);
           
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var res1 = eggDrop.FindMinAttemptsRecurse(eggs, floors);
            sw.Stop();

            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("Answer by Recursive solution = {0} ", res1);
            System.Console.WriteLine("Time Taken by Recursive solution = {0} ticks \n\n", sw.ElapsedTicks);            


            sw.Restart();
            var res2 = eggDrop.FindMinAttemptsMemonize(eggs, floors);
            sw.Stop();

            System.Console.ForegroundColor = ConsoleColor.Magenta;
            System.Console.WriteLine("Answer by Memonized solution = {0} ", res2);
            System.Console.WriteLine("Time Taken by Memonized solution = {0} ticks \n\n", sw.ElapsedTicks);


            sw.Restart();
            var res3 = eggDrop.FindMinAttempts(eggs, floors);
            sw.Stop();

            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("Answer by Formulae(DP) solution = {0} ", res3);
            System.Console.WriteLine("Time Taken by Formulae(DP) solution = {0} ticks \n\n", sw.ElapsedTicks);

            

            Console.WriteLine();

        }
    }
}
