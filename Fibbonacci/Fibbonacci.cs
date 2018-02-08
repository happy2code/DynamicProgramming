namespace Fibbonacci
{
    public static class Implementation 
    {
        private static long[] values = new long[50];
        public static long Fib1(long N)
        {
            if (N == 1)
                return 0;
            if (N == 2)
                return 1;

            return Fib1(N-1) + Fib1(N-2);
        }

        public static long Fib2(long N)
        {
            if (N <= 2)
            {               
                values[N - 1] = N -1;               
                return values[N-1];
            }

            if (values[N-1] != 0)
            {                
                return values[N - 1];
            }
            
            return values[N - 1] = Fib2(N - 1) + Fib2(N - 2);
        }        
    }
}