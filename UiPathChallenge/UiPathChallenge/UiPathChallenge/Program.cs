using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UiPathChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            int x1 = Convert.ToInt32(Console.ReadLine());
            int y1 = Convert.ToInt32(Console.ReadLine());
            int z1 = Convert.ToInt32(Console.ReadLine());
            int x2 = Convert.ToInt32(Console.ReadLine());
            int y2 = Convert.ToInt32(Console.ReadLine());
            int z2 = Convert.ToInt32(Console.ReadLine());

            Point3D p1 = new Point3D(x1, y1, z1);
            Point3D p2 = new Point3D(x2, y2, z2);
            double d2 = p1.dist2D(p2);
            double d3 = p1.dist3D(p2);
            //The code below uses runtime polymorphism to call the overridden printDistance method:
            Point2D p = new Point2D(0, 0);
            p.printDistance(d2);
            p = p1;
            p1.printDistance(d3);
        }
    }
}
