using System;

namespace CoinChange
{
    class Program
    {
        public static long MakeChange(int[] coins, int money, int index)
        {
            if(money == 0){
                return 1;
            }

            if(index >= coins.Length){
                return 0;
            }

            int amountWithCoin = 0;
            long ways = 0;
            while(amountWithCoin <= money)
            {
                int remaining = money - amountWithCoin;                
                amountWithCoin += coins[index];

                ways += MakeChange(coins, remaining, index + 1);
            }
            return ways;
        }
        static void Main(string[] args)
        {
            const int Amount = 5;
            int[] denominations = { 1,2,5,10 };
            Console.WriteLine(MakeChange(denominations,5,0));
            
        }
    }
}
