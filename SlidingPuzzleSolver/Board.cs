using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlidingPuzzleSolver
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public class Board
    {
        public int[,] board { get; private set;}

        public Board() { }

        /// <param name="order">Essentially "width"</param>
        public Board(int order)
        {
            this.Initialise(order);
        }

        /// <param name="order">Essentially "width"</param>
        public void Initialise(int order)
        {
            board = new int[order, order];
        }
    }
}
