using System;
using System.Collections.Generic;

namespace Rokos
{
    public class CodilityTest
    {
        public int Solution2(string S)
        {
            var stringAsNumber = Convert.ToInt32(S, 2);

            var counter = 0;

            while(stringAsNumber > 0)
            {
                if(stringAsNumber % 2 == 0)
                {
                    stringAsNumber /= 2;
                }
                else
                {
                    stringAsNumber--;
                }

                counter++;
            }

            return counter;
        }

        public int Solution3(Tree T)
        {
            int runningMaxLeft = 0;
            int runningMaxRight = 0;
            List<int> rightPath = new List<int>();

            if (T.l != null)
            {
                AdjustLength(T.l, new List<int> { T.x }, ref runningMaxLeft);
            }

            if (T.r != null)
            {
                AdjustLength(T.r, new List<int> { T.x }, ref runningMaxRight);
            }

            return Math.Max(runningMaxLeft, runningMaxRight);
        }

        private void AdjustLength(Tree T, List<int> distinctValues, ref int runningMax)
        {
            if(!distinctValues.Contains(T.x))
            {
                distinctValues.Add(T.x);

                if(distinctValues.Count > runningMax)
                {
                    runningMax = distinctValues.Count;
                }

                if (T.l != null)
                {
                    AdjustLength(T.l, new List<int>(distinctValues), ref runningMax);
                }

                else if (T.r != null)
                {
                    AdjustLength(T.r, new List<int>(distinctValues), ref runningMax);
                }
            }
        }
    }
    public class Tree
    {
        public int x;
        public Tree l;
        public Tree r;

        public Tree(int x, Tree l, Tree r)
        {
            this.x = x;
            this.l = l;
            this.r = r;
        }
    };
}
