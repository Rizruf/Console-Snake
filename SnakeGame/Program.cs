namespace SnakeGame
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 25);
            Console.CursorVisible = false;

            Snake snake = new Snake(10, 10, 5);
            FoodCreater foodCreator = new FoodCreater(80, 25, '$');
            Walls walls = new Walls (Console.WindowWidth, Console.WindowHeight);

            walls.DrawWalls();
            Point food = foodCreator.CreateFood();
            food.Print();
            

            while (true)
            {

                Point nextHead = snake.GetNextPoint();

                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Print();
                }
                else
                {
                    snake.Move();
                }

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    snake.HandleKey(key.Key);
                }

                if (walls.IsHit(nextHead) /*|| snake.IsHitTail(nextHead)*/)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("GAME OVER! (Нажми Enter)");
                    break;
                }

                Thread.Sleep(100);
            }

            Console.ReadLine();
        }
    }
}
