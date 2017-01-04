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

        public void MoveTile(Point p, Direction d)
        {
            int selected = board[p.X, p.Y];

            Point tPoint = new Point(p.X, p.Y);

            switch (d)
            {
                case Direction.Up:
                    p.Y++;
                    break;
                case Direction.Down:
                    p.Y--;
                    break;
                case Direction.Left:
                    p.X--;
                    break;
                case Direction.Right:
                    p.X++;
                    break;
            }

            int target = board[tPoint.X, tPoint.Y];

            //add check
            board[p.X, p.Y] = target;
            board[tPoint.X, tPoint.Y] = selected;
        }
    }
}
