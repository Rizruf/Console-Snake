using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class Snake
    {
        public enum Direction { Left, Right, Up, Down }

        Queue<Point> _body;
        Direction _direction;

        public Snake(int x, int y, int length)
        {
            _body = new Queue<Point>();
            _direction = Direction.Right;

            for (int i = 0; i <= length; i++)
            {
                Point point = new Point(x + i, y, '#');
                _body.Enqueue(point);
            }
        }

        public void Draw()
        {
            foreach (Point point in _body)
            {
                point.Print();
            }
        }

        public Point GetNextPoint()
        {
            Point head = _body.Last();

            Point nextPoint = new Point(head.Left, head.Top, head.Symbol);

            switch (_direction)
            {
                case Direction.Left:
                    nextPoint.Left -= 1;
                    break;
                case Direction.Right:
                    nextPoint.Left += 1;
                    break;
                case Direction.Up:
                    nextPoint.Top -= 1;
                    break;
                case Direction.Down:
                    nextPoint.Top += 1;
                    break;
            }

            return nextPoint;
        }

        public void Move()
        {
            Point head = GetNextPoint();

            _body.Enqueue(head);
            head.Print();

            Point tail = _body.Dequeue();
            tail.Clear();
        }

        public bool Eat(Point food)
        {
            Point head = GetNextPoint();
            if (head.Left == food.Left && head.Top == food.Top)
            {
                food.Symbol = head.Symbol;
                _body.Enqueue(food);
                return true;
            }
            return false;
        }

        public bool IsHitTail(Point part)
        {

            foreach (var bodyPart in _body)
            {
                if (part.Left == bodyPart.Left && part.Top == bodyPart.Top)
                    return true;
            }
            return false;
        }

        public void HandleKey(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    _direction = Direction.Left;
                    break;

                case ConsoleKey.UpArrow:
                    if (_direction != Direction.Down)
                        _direction = Direction.Up;
                    break;

                case ConsoleKey.RightArrow:
                    _direction = Direction.Right;
                    break;

                case ConsoleKey.DownArrow:
                    if (_direction != Direction.Up)
                        _direction = Direction.Down;
                    break;


                case ConsoleKey.W:
                    if (_direction != Direction.Down)
                        _direction = Direction.Up;
                    break;

                case ConsoleKey.S:
                    if (_direction != Direction.Up)
                        _direction = Direction.Down;
                    break;

                case ConsoleKey.D:
                    _direction = Direction.Right;
                    break;

                case ConsoleKey.A:
                    _direction = Direction.Left;
                    break;
            }
        }
    }
}
