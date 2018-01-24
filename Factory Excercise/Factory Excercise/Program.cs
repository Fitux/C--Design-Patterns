using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Factory_Excercise
{
    class Program
    {
        public class Point
        {
            private double x, y;

            private Point(double x, double y)
            {
                this.x = x;
                this.y = y;

                //switch (system)
                //{
                //    case CoordinateSystem.Cartesian:
                //        this.x = a;
                //        this.y = b;
                //        break;
                //    case CoordinateSystem.Polar:
                //        this.x = a * Math.Cos(b);
                //        this.y = a * Math.Sin(b);
                //        break;
                //    default:
                //        throw new ArgumentOutOfRangeException(nameof(system), system, null);
                //}
            }

            public override string ToString()
            {
                return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
            }

            public static Point Origin = new Point(0, 0);

            public static class Factory
            {
                public static Point NewCartesianPoint(double x, double y)
                {
                    return new Point(x, y);
                }

                public static Point NewPolarPoint(double rho, double theta)
                {
                    return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
                }
            }
        }

        static void Main(string[] args)
        {
            var point = Point.Factory.NewPolarPoint(1.0, Math.PI / 2);
            WriteLine(point);
        }
    }
}
