namespace Rokos
{
    class Program
    {
        static void Main(string[] args)
        {
            //var r = DemoTask.Solution(new[] { -1, -3 }); // DemoTask.Solution(new[] { 1, 2, 3 });//DemoTask.Solution(new[] { 1, 3, 6, 4, 1, 2 });

            //var r = CodilityTest.Solution1("011100");

            var T = new Tree ( 1, new Tree(2, new Tree(3, new Tree(2, null, null), null), new Tree(6, null, null)), new Tree(3, new Tree(3, null, null), new Tree(1, new Tree(5, null, null), new Tree(6, null, null))));

            var r = new CodilityTest().Solution3(T);
        }
    }
}
