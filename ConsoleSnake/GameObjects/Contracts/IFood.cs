namespace ConsoleSnake.GameObjects.Contracts
{
    using System.Collections.Generic;

    public interface IFood
    {
        int FoodPoints { get; set; }

        double SpeedIncrease { get; set; }
        
        void SetRandomPosition(Queue<Point> snakeElements);

        bool IsFoodPoint(Point snake);
    }
}
