using System;
using System.Collections.Generic;

namespace CoinChange
{
    class Program
    {
        private static Dictionary<string, long> _solution = new Dictionary<string, long>();
        public static long MakeChange(int[] coins, int amountToMake)
        {
            return MakeChange(coins, amountToMake, 0);
        }
        private static long MakeChange(int[] coins, int amountToMake, int index)
        {
            if(amountToMake == 0){
                return 1;
            }       
            if(index >= coins.Length){
                return 0;
            }

            int amountMadeTillNow = 0;
            long solutionCount = 0;
            while(amountMadeTillNow <= amountToMake)
            {
                int remaining = amountToMake - amountMadeTillNow;
                amountMadeTillNow += coins[index];

                solutionCount += MakeChange(coins, remaining, index + 1);
            }
            return solutionCount;
        }

        public static long MakeChangeMemonized(int[] coins, int amountToMake)
        {
            return MakeChangeMemonized(coins, amountToMake, 0);
        }
        public static long MakeChangeMemonized(int[] coins, int amountToMake, int index)
        {
            if (amountToMake == 0)
            {
                return 1;
            }
            if (index >= coins.Length)
            {
                return 0;
            }
            string key = amountToMake + "-" + index;
            if(_solution.ContainsKey(key)) return _solution[key];
            

            int amountMadeTillNow = 0;
            long solutionCount = 0;
            while (amountMadeTillNow <= amountToMake)
            {
                int remaining = amountToMake - amountMadeTillNow;
                amountMadeTillNow += coins[index];
                
                solutionCount += MakeChange(coins, remaining, index + 1);
            }
            
            _solution[key] = solutionCount;
            return solutionCount;
        }
        static void Main(string[] args)
        {
            const int Amount = 100;
            int[] denominations = {2, 1};
            Console.WriteLine(MakeChange(denominations, Amount));
            Console.WriteLine(MakeChangeMemonized(denominations, Amount));

        }
    }
}
