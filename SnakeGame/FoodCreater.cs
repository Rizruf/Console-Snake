using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class FoodCreater
    {
        int _mapWidth;
        int _mapHeight;
        char _sym;
        Random _random = new Random();

        public FoodCreater(int mapWidth, int mapHeight, char symbol)
        {
            _mapWidth = mapWidth;
            _mapHeight = mapHeight;
            _sym = symbol;
        }

        public Point CreateFood()
        {
            int x = _random.Next(2, _mapWidth - 2);
            int y = _random.Next(2, _mapHeight - 2);
            return new Point(x, y, _sym);
        }
    }
}
