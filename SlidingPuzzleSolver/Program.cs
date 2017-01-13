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

            Board b = new Board(4,true);
            //b.Populate(new int[,] {{ 0, 1, 2 },
            //                      { 3, 4, 5 },
            //                      { 6, 7, 8 } });
            //b.Populate(new int[,] {{ 0, 1, 2, 3 },
            //                      { 4, 5, 6, 7 },
            //                      { 8, 9, 10, 11 },
            //                      { 12,13,14, 15 } });
            //TODO make custom table class
            Console.WriteLine(b.GetFitness());
            Console.WriteLine(b.Print());

            Console.WriteLine(b.MoveTile(Direction.Left));
            Console.WriteLine(b.Print());


        }
    }
    
}
