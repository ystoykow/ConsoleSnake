namespace ConsoleSnake.GameObjects
{
    using Contracts;

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Food : Point, IFood
    {
        private Random random;
        private Wall wall;
        private char foodSymbol;

        protected Food(Wall wall, char foodSymbol, int points)
            : base(wall.LeftX, wall.TopY)
        {
            this.random = new Random();
            this.wall = wall;
            this.foodSymbol = foodSymbol;
            this.FoodPoints = points;
        }

        public int FoodPoints { get; set; }

        public double SpeedIncrease { get; set; }

        public void SetRandomPosition(Queue<Point> snakeElements)
        {
            do
            {
                this.LeftX = random.Next(2, wall.LeftX - 2);
                this.TopY = random.Next(2, wall.TopY - 2);

            } while (snakeElements
                .Any(e => e.TopY == this.TopY
                          && e.LeftX == this.LeftX));

            Console.BackgroundColor = ConsoleColor.Red;
            this.Draw(foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }

        public bool IsFoodPoint(Point snake)
        {
            return snake.TopY == this.TopY && snake.LeftX == this.LeftX;
        }
    }
}
