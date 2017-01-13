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
        public static bool DEBUG_MANIP = false;

        /// <summary>
        /// Y,X
        /// </summary>
        public int[,] board { get; private set;}

        public Board() { }

        /// <param name="order">Essentially "width"</param>
        public Board(int order, bool fill = false)
        {
            this.Initialise(order, fill);
        }

        /// <param name="order">Essentially "width"</param>
        public void Initialise(int order, bool fill=false)
        {
            board = new int[order, order];
            if (fill)
            {
                int no = 0;
                for (int y = 0; y < this.board.GetLength(1); y++)
                {
                    for (int x = 0; x < this.board.GetLength(0); x++)
                    {
                        this.board[x, y] = no;
                        no++;
                    }
                }
            }
        }

        public void Populate(int[,] map)
        {
            this.Initialise(map.GetLength(0));
            for (int y = 0; y < board.GetLength(1); y++)
            {
                for (int x = 0; x < board.GetLength(0); x++)
                {
                    this.board[x, y] = map[y, x];
                }
            }
        }

        public Point GetEmpty()
        {
            for (int y = 0; y < this.board.GetLength(1); y++)
            {
                for (int x = 0; x < this.board.GetLength(0); x++)
                {
                    if (this.board[x, y] == 0)
                    {
                        return new Point(x, y);
                    }
                }
            }
            return null;
        }

        /// <returns>MoveTile successful or not</returns>
        public bool MoveTile(Direction d)
        {
            return MoveTile(this.GetEmpty(), d);
        }

        /// <returns>MoveTile successful or not</returns>
        public bool MoveTile(Point p, Direction d)
        {
            int selected = board[p.X, p.Y];
            if (selected != 0) return false;

            Point tPoint = new Point(p.X, p.Y);

            switch (d)
            {
                case Direction.Up:
                    tPoint.Y--;
                    break;
                case Direction.Down:
                    tPoint.Y++;
                    break;
                case Direction.Left:
                    tPoint.X++;
                    break;
                case Direction.Right:
                    tPoint.X--;
                    break;
            }

            try
            {
                int target = board[tPoint.X, tPoint.Y];

            
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
            if(DEBUG_MANIP)
            Console.WriteLine(p + "SELETED: " + selected);
            if (selected == 0) return 0;
            int ret = 0;
            for (int i = selflat; i < flat.Length; i++)
            {
                if (DEBUG_MANIP)
                    Console.Write("\t" + flat[i]);
                if (flat[i] < selected)
                {
                    Console.Write("!");
                    ret += flat[i]+1;
                }
                if (DEBUG_MANIP)
                    Console.WriteLine();
            }
            return ret;
        }

        public int GetFitness()
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

        public string Print()
        {
            StringBuilder sb = new StringBuilder();
            for (int y = 0; y < this.board.GetLength(1); y++)
            {
                for (int x = 0; x < this.board.GetLength(0); x++)
                {
                    string s = this.board[x, y].ToString();
                    sb.Append(s);
                    sb.Append(' ', 3 - s.Length);
                    if (x < -this.board.GetLength(0) - 1)
                    {
                        sb.Append(',');
                    }
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public void DisplayBoard()
        {
            Console.WriteLine(this.Print());
            Console.WriteLine();
            Console.WriteLine("Fitness: " + this.GetFitness());
        }
    }
}
