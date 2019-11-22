namespace ConsoleSnake.GameObjects
{
    using Contracts;
    using Foods;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Snake
    {
        private const char SnakeSymbol = '\u25CF';
        private const char EmptySpace = ' ';
        private const double StartSpeed = 100;

        private Queue<Point> snakeElements;
        private List<IFood> food;
        private Wall wall;
        private int foodIndex;
        private int nextTopY;
        private int nextLeftX;

        public Snake(Wall wall)
        {
            this.wall = wall;
            this.snakeElements = new Queue<Point>();
            this.SpeedLevel = StartSpeed;
            this.food = new List<IFood>
            {
                new FoodAsterisk(this.wall),
                new FoodDollar(this.wall),
                new FoodGod(this.wall),
                new FoodHash(this.wall),
                new FoodSlow(this.wall)
            };

            this.foodIndex = RandomFoodNumber;
            this.food[foodIndex].SetRandomPosition(snakeElements);
            this.CreateSnake();
        }

        public double SpeedLevel { get; set; }

        public int Score { get; private set; }

        private int RandomFoodNumber => new Random().Next(0, this.food.Count);

        public bool IsMoving(Point direction)
        {
            Point currentSnakeHead = this.snakeElements.Last();
            GetNextPoint(direction, currentSnakeHead);
            bool isPointOfSnake = this.snakeElements.Any(e => e.LeftX == this.nextLeftX && e.TopY == this.nextTopY);
            if (isPointOfSnake)
            {
                return false;
            }

            Point snakeNewHead = new Point(this.nextLeftX, this.nextTopY);
            if (this.wall.IsPointOfWall(snakeNewHead))
            {
                return false;
            }

            this.snakeElements.Enqueue(snakeNewHead);
            snakeNewHead.Draw(SnakeSymbol);

            if (food[foodIndex].IsFoodPoint(snakeNewHead))
            {
                this.Eat(direction, currentSnakeHead);

            }

            Point snakeTail = this.snakeElements.Dequeue();
            snakeTail.Draw(EmptySpace);
            
            return true;
        }

        private void CreateSnake()
        {
            for (int topY = 1; topY <= 6; topY++)
            {
                this.snakeElements.Enqueue(new Point(2, topY));
            }
        }

        private void GetNextPoint(Point direction, Point snakeHead)
        {
            this.nextLeftX = snakeHead.LeftX + direction.LeftX;
            this.nextTopY = snakeHead.TopY + direction.TopY;
        }

        private void Eat(Point direction, Point currentSnakeHead)
        {
            int snakeAdditionalLength = food[foodIndex].FoodPoints;
            this.SpeedLevel += food[foodIndex].SpeedIncrease;
            for (int i = 0; i < snakeAdditionalLength; i++)
            {
                this.Score++;
                this.snakeElements.Enqueue(new Point(this.nextLeftX, this.nextTopY));
                GetNextPoint(direction, currentSnakeHead);
            }

            this.foodIndex = this.RandomFoodNumber;
            this.food[foodIndex].SetRandomPosition(this.snakeElements);
        }
    }
}
