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

        public void Populate(int[,] map)
        {
            this.Initialise(map.GetLength(1));
            for (int y = 0; y < board.GetLength(1); y++)
            {
                for (int x = 0; x < board.GetLength(0); x++)
                {
                    this.board[x, y] = map[y, x];
                }
            }
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

            try
            {
                int target = board[tPoint.X, tPoint.Y];

                if (target != 0) return false;
            
            board[p.X, p.Y] = target;
            board[tPoint.X, tPoint.Y] = selected;
            }
            catch
            {
                return false;
            }

            return true;
        }

        public int[] Flatten()
        {
            int[] ret = new int[this.board.GetLength(0) * this.board.GetLength(1)]; 
            for (int y = 0; y < this.board.GetLength(1); y++)
            {
                for (int x = 0; x < this.board.GetLength(0); x++)
                {
                    ret[(y*this.board.GetLength(0))+x] = this.board[x, y];
                }
            }
            return ret;
        }

        public int CountFitness(Point p)
        {
            int selflat = (p.Y * board.GetLength(0)) + p.X;
            int[] flat = Flatten();
            int selected = flat[selflat];
            Console.WriteLine(p + "SELETED: " + selected);
            if (selected == 0) return 0;
            int ret = 0;
            for (int i = 0; i < flat.Length; i++)
            {
                Console.Write("\t" + flat[i]);
                if (flat[i] < selected)
                {
                    Console.Write("!");
                    ret += flat[i]+1;
                }
                Console.WriteLine();
            }
            return ret;
        }

        public int CountFitness()
        {
            int ret = 0;
            for (int y = 0; y < this.board.GetLength(1); y++)
            {
                for (int x = 0; x < this.board.GetLength(0); x++)
                {
                    ret += CountFitness(new Point(x, y));
                }
            }

            return ret;
        }
    }
}
