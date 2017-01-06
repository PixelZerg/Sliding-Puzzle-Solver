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
        public int[,] board { get; set;}

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

        /// <returns>MoveTile successful or not</returns>
        public bool MoveTile(Point p, Direction d)
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

            if (target != 0) return false;

            board[p.X, p.Y] = target;
            board[tPoint.X, tPoint.Y] = selected;

            return true;
        }

        public int CountFitness(Point p)
        {
            int selected = this.board[p.X, p.Y];
            if (selected == 0) return 0;
            int ret = 0;
            for (int x = p.X; x < this.board.GetLength(0); x++)
            {
                for (int y = p.Y; y < this.board.GetLength(1); y++)
                {
                    int i = this.board[x, y];

                    if (i < selected)
                    {
                        if(i == 0) { i++; }
                        ret += (i);
                    }
                }
            }
            return ret;
        }
    }
}
