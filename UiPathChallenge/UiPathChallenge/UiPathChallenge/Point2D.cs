using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UiPathChallenge
{
    public class Point2D
    {
        public Point2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; protected set; }

        public double Y { get; protected set; }

        public double dist2D(Point2D point2D)
        {
            return Math.Sqrt(Math.Pow(point2D.X - X, 2D) + Math.Pow(point2D.Y - Y, 2D));
        }

        public virtual void printDistance(double d)
        {
            int result = 0;
            Int32.TryParse(Math.Ceiling(d).ToString(), out result);
            Console.WriteLine($"2D distance = {result}");
        }
    }
}
