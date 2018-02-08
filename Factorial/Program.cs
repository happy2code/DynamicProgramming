using System;

namespace Factorial
{
    class Program
    {            
        static ulong Factorial(uint number)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Calculating factorial of {0}", number);
            if(number == 0 || number == 1)
            {
                return 1;
            }
          
            return number * Factorial(number - 1);
        }


        static void Main(string[] args)
        {
            var res1 = Factorial(10);           
        }
    }
}
