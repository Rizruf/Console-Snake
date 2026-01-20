using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class Walls
    {
        private int _mapWidth = Console.WindowWidth;
        private int _mapHeight = Console.WindowHeight;

        List <Point> wallsList = new List <Point> ();



        public Walls(int mapWidth, int mapHeight)
        {
            _mapHeight = mapHeight;
            _mapWidth = mapWidth;

            for (int x = 0; x < mapWidth; x++)
            {
                Point pointTop = new Point (x,0,'*'); // Верхняя граница (Top = 0)
                Point pointxButton = new Point(x, mapHeight - 1, '#'); // Нижняя граница (Top = Height)

                wallsList.Add (pointTop);
                wallsList.Add (pointxButton);
            }

            for (int y = 0; y < mapHeight; y++)
            {
                Point pointLeft = new Point(0, y, '*'); // Левая (Left = 0)
                Point pointyRight = new Point(mapWidth - 1, y, '*'); // Правая (Right = 0)

                wallsList.Add(pointLeft);
                wallsList.Add(pointyRight);
            }
        }

        public void DrawWalls()
        {
            foreach (var walls in wallsList)
            {
                walls.Print();
            }
        }

        public bool IsHit(Point p)
        {
            foreach (var wall in wallsList)
            {
                if (p.Left == wall.Left && p.Top == wall.Top)
                {
                    return true;
                }
            }
            return false;
        }

        


    }
}
