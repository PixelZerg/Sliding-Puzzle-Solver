using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlidingPuzzleSolver
{
    public static class Program
    {
        public static void Main()
        {
            /*
                1 2 0
                3 4 5
                6 7 8
            */

            Board b = new Board(3);
            b.board = new int[,] {{ 1, 2, 0 }, { 3, 4, 5 }, { 6, 7, 8 } };
            Console.WriteLine(b.CountFitness(new Point(0, 1)));//NEED TO FIX!

        }
    }
}
