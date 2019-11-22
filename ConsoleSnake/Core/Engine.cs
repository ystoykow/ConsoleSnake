namespace ConsoleSnake.Core
{
    using Contracts;
    using Enums;
    using GameObjects;
    using System;
    using System.Threading;

    public class Engine : IEngine
    {
        private Wall wall;
        private Snake snake;
        private Point[] pointOfDirection;
        private Direction direction;

        public Engine(Wall wall, Snake snake)
        {
            this.wall = wall;
            this.snake = snake;
            this.pointOfDirection = new Point[4];
        }

        public void Run()
        {
            this.CreateDirections();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    GetNextDirection();
                }

                bool isMoving = snake.IsMoving(this.pointOfDirection[(int)direction]);

                if (!isMoving)
                {
                    AskUserForRestart();
                }

                ShowInfo();
                Thread.Sleep((int)snake.SpeedLevel);
            }
        }

        private void CreateDirections()
        {
            this.pointOfDirection[0] = new Point(1, 0);
            this.pointOfDirection[1] = new Point(-1, 0);
            this.pointOfDirection[2] = new Point(0, 1);
            this.pointOfDirection[3] = new Point(0, -1);
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            if (userInput.Key == ConsoleKey.LeftArrow)
            {
                if (direction != Direction.Right && direction!=Direction.Left)
                {
                    snake.SpeedLevel -= 50;
                    direction = Direction.Left;
                }
            }
            else if (userInput.Key == ConsoleKey.RightArrow)
            {
                if (direction != Direction.Left && direction!=Direction.Right)
                {
                    snake.SpeedLevel -= 50;
                    direction = Direction.Right;
                }
            }
            else if (userInput.Key == ConsoleKey.UpArrow)
            {
                if (direction != Direction.Down && direction!=Direction.Up)
                {
                    snake.SpeedLevel += 50;
                    direction = Direction.Up;
                }
            }
            else if (userInput.Key == ConsoleKey.DownArrow)
            {
                if (direction != Direction.Up && direction!=Direction.Down)
                {
                    snake.SpeedLevel += 50;
                    direction = Direction.Down;
                }
            }

            Console.CursorVisible = false;
        }
        private void ShowInfo()
        {
            Console.SetCursorPosition(18, 20);
            Console.Write($"Score: {snake.Score} Speed: {snake.SpeedLevel} ");
            Console.SetCursorPosition(0, 21);
            Console.WriteLine($"Legend:");
            Console.WriteLine($" *   1 points and increase speed with 0.1");
            Console.WriteLine($" $   2 points and increase speed with 0.4");
            Console.WriteLine($" #   3 points and increase speed with 0.9");
            Console.WriteLine($" &   5 points and increase speed with 2.5");
            Console.WriteLine($" @   1 points and decrease speed with 2");
        }

        private void AskUserForRestart()
        {
            int leftX = this.wall.LeftX + 3;
            int topY = 3;
            Console.SetCursorPosition(leftX, topY);
            Console.Write($"Would you like to continue? y/n");
            string input = Console.ReadLine();

            if (input == "y")
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                StopGame();
            }
        }

        private void StopGame()
        {
            Console.SetCursorPosition(20, 10);
            Console.Write("Game Over!");
            Environment.Exit(0);
        }
    }
}
