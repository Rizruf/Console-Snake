namespace SnakeGame
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            int score = 0;
            int speed = 150; 

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

                if (walls.IsHit(nextHead) || snake.IsHitTail(nextHead))
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("GAME OVER! (Нажми Enter)");
                    break;
                }

                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    score++;

                    Console.Title = $"Snake Score: {score}";

                    if (speed > 30)
                    {
                        speed -= 5;
                    }

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

                Thread.Sleep(speed);
            }

            Console.ReadLine();
        }
    }
}
