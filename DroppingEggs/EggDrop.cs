using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DroppingEggs
{
    public class EggDrop
    {
        int _eggCount;
        int _floorCount;
        int[,] _solutionMatrix;
        int[,] _solutionMatrix2;        

        public EggDrop(int eggCount, int floorCount)
        {
            _eggCount = eggCount;
            _floorCount = floorCount;
            _solutionMatrix = new int[_eggCount + 1, _floorCount + 1];
            _solutionMatrix2 = new int[_eggCount + 1, _floorCount + 1];           
            InitMatrix();
        }

        void InitMatrix()
        {
            for (int row = 0; row <= _eggCount; row++) _solutionMatrix[row, 0] = 0;
            for (int col = 0; col <= _floorCount; col++) _solutionMatrix[0, col] = 0;
            for (int col = 0; col <= _floorCount; col++) _solutionMatrix[1, col] = col;           
        }

        public int FindMinAttemptsRecurse(int eggCount, int floorCount)
        {
            if (eggCount == 1)
            {
                return floorCount;
            }

            if (floorCount == 1)
            {
                return 1;
            }

            int minDrops = int.MaxValue;
            for (int currentFloor = 1; currentFloor < floorCount; currentFloor++)
            {
                var attemptsAtCurrentFloor = 1 + Math.Max(FindMinAttemptsRecurse(eggCount - 1, currentFloor - 1), FindMinAttemptsRecurse(eggCount, floorCount - currentFloor));
                if (attemptsAtCurrentFloor < minDrops)
                {
                    minDrops = attemptsAtCurrentFloor;
                }
            }

            return minDrops;
        }

        public int FindMinAttemptsMemonize(int eggCount, int floorCount)
        {
            if (eggCount == 1) { return floorCount;}
            if (floorCount == 1){ return 1; }

            if (_solutionMatrix2[eggCount, floorCount] != 0){
                return _solutionMatrix2[eggCount, floorCount];
            }

            int minDrops = int.MaxValue;
            for (int currentFloor = 1; currentFloor < floorCount; currentFloor++){
                var attemptsAtCurrentFloor = 1 + Math.Max(FindMinAttemptsMemonize(eggCount - 1, currentFloor - 1), FindMinAttemptsMemonize(eggCount, floorCount - currentFloor));
                if (attemptsAtCurrentFloor < minDrops) {
                    minDrops = attemptsAtCurrentFloor;
                }
            }
            return _solutionMatrix2[eggCount, floorCount] = minDrops;
        }

        public int FindMinAttempts(int eggCount, int floorCount)
        {
            for (int i = 2; i <= eggCount; i++)
            {
                for (int j = 1; j <= floorCount; j++)
                {

                    if (i > j)
                    {
                        _solutionMatrix[i, j] = _solutionMatrix[i - 1, j];
                    }
                    else
                    {
                        int minVal = int.MaxValue;
                        for (int k = 0; k < j - 1; k++)
                        {
                            minVal = Math.Min(minVal, Math.Max(_solutionMatrix[i - 1, k], _solutionMatrix[i, j - k - 1]));
                        }

                        _solutionMatrix[i, j] = 1 + minVal;
                    }
                }
            }
            return _solutionMatrix[eggCount, floorCount];
        }
        
        public void PrintSolutionMatrix()
        {
            for (int i = 0; i <= _eggCount; i++)
            {
                Console.WriteLine();
                for (int j = 0; j <= _floorCount; j++)
                {
                    var val = string.Format("{0,3}", _solutionMatrix[i, j]);
                    Console.Write(val);
                }
            }
        }
    }
}
