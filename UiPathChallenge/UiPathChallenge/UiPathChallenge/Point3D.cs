using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UiPathChallenge
{
    public class Point3D : Point2D
    {
        public Point3D(double x, double y, double z) : base(x, y)
        {
            Z = z;
        }

        public double Z { get; private set; }

        public double dist3D(Point3D point3D)
        {
            return Math.Sqrt(Math.Pow(point3D.X - X, 2D) + Math.Pow(point3D.Y - Y, 2D) + Math.Pow(point3D.Z - Z, 2D));
        }

        public override void printDistance(double d)
        {
            int result = 0;
            Int32.TryParse(Math.Ceiling(d).ToString(), out result);
            Console.WriteLine($"3D distance = {result}");
        }
    }
}
