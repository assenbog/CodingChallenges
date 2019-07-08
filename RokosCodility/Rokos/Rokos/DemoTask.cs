using System.Linq;

namespace Rokos
{
    public static class DemoTask
    {
        public static int Solution(int[] A)
        {
            var distinctOrderedPositives = A.Where(p => p > 0).Distinct().OrderBy(p => p).ToArray();

            if(distinctOrderedPositives.Length == 0)
            {
                return 1;
            }

            for(var i = 0; i < distinctOrderedPositives.Length - 1; i++)
            {
                if(distinctOrderedPositives[i + 1] - distinctOrderedPositives[i] > 1)
                {
                    return distinctOrderedPositives[i] + 1;
                }
            }

            return distinctOrderedPositives[distinctOrderedPositives.Length - 1] + 1;
        }
    }
}
