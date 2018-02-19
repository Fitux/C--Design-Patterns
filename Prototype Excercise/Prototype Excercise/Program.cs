using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype_Excercise
{
    namespace Coding.Exercise
    {
        public class Point
        {
            public int X, Y;

            public Point (int X, int Y)
            {
                this.X = X;
                this.Y = Y;
            }

            public Point Clone()
            {
                return new Point(this.X, this.Y);
            }
        }

        public class Line
        {
            public Point Start, End;

            public Line (Point Start, Point End)
            {
                if (this.Start == null)
                    throw new ArgumentNullException("Argument Null");

                if (this.End == null)
                    throw new ArgumentNullException("Argument Null");

                this.Start = Start;
                this.End = End;
            }

            public Line DeepCopy()
            {
                return new Line(this.Start.Clone(), this.End.Clone());
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
