namespace ArrayFunction1
{
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[] { 1, 2, 3, 5, 6, 2, 3, 1, 6 };

            var single = GetSingleInteger(numbers);
        }

        static int GetSingleInteger(int[] numbers)
        {
            return numbers.GroupBy(p => p).Where(p => p.Count() == 1).Select(p => p.Key).FirstOrDefault();
            //var a = from number in numbers
            //        group number by number into numberGroups
            //        where numberGroups.Count == 1
            //        select numberGroups.
        }
    }
}
