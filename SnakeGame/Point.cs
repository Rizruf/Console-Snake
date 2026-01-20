using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    struct Point
    {
        public int Top { get; set; }
        public int Left { get; set; }
        public char Symbol { get; set; }

        public Point(int left, int top, char symbol)
        {
           Top = top;
           Left = left;
           Symbol = symbol;
        }

        public void Print()
        {
            Console.SetCursorPosition(Left, Top);
            Console.Write(Symbol);
        }

        public void Clear()
        {
            Console.SetCursorPosition(Left, Top);
            Console.Write(' ');
        }
    }
}
