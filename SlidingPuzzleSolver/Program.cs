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
                0 1 2
                3 4 5
                6 7 8
            */

            Board b = new Board(4);
            b.Populate(new int[,] {{ 1, 0, 2 },
                                  { 3, 4, 5 },
                                  { 6, 7, 8 } });
            //b.board = new int[,] {{ 0, 1, 2, 3 },
            //                      { 4, 5, 6, 7 },
            //                      { 8, 9, 10, 11 } };
            //TODO make custom table class
            Console.WriteLine(b.CountFitness());
            //Console.WriteLine(b.board[2, 0]);

        }
    }
    
}
