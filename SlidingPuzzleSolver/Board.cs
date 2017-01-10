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
        /// <summary>
        /// Y,X
        /// </summary>
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
            int selected = board[p.Y, p.X];

            Point tPoint = new Point(p.Y, p.X);

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

            int target = board[tPoint.Y, tPoint.X];

            if (target != 0) return false;

            board[p.Y, p.X] = target;
            board[tPoint.Y, tPoint.X] = selected;

            return true;
        }

        public int CountFitness(Point p)
        {
            int selected = this.board[p.Y, p.X];
            Console.WriteLine(p + "SELETED: " + selected);
            if (selected == 0) return 0;
            int ret = 0;

            int xn = p.X;
            int yn = p.Y;
            xn++;
            if (xn == this.board.GetLength(0))
            {
                xn = 0;
                if (yn < this.board.GetLength(1))
                {
                    yn++;
                }
            }

            for (int x = xn; x < this.board.GetLength(0); x++)
            {
                for (int y = yn; y < this.board.GetLength(1); y++)
                {
                    int i = this.board[y, x];
                    Console.Write("\t"+i);
                    Console.WriteLine(i < selected);
                    if (i < selected)
                    {
                        if(i == 0) { i++; }
                        ret += (i);
                    }
                }
            }
            return ret;
        }

        public int CountFitness()
        {
            int ret = 0;
            for (int x = 0; x < this.board.GetLength(0); x++)
            {
                for (int y = 0; y < this.board.GetLength(1); y++)
                {
                    ret+=CountFitness(new Point(y, x));
                }
            }
            return ret;
        }
    }
}
