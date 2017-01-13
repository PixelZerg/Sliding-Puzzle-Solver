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
            Console.Write("Generating random board...");
            Board b = Board.GetRandomBoard(5,1000,true);
            Console.WriteLine("[OK!]"+Environment.NewLine);
            b.DisplayBoard();
        }
    }
    
}
