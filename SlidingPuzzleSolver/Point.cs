using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlidingPuzzleSolver
{
    public class Point
    {
        public int X = -1;
        public int Y = -1;

        public Point()
        {
        }

        public Point(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public override string ToString()
        {
            return "{\"X\":" + X + ",\"Y\":" + Y + "}";
        }

    }
}
