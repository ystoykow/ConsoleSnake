namespace ConsoleSnake.GameObjects.Foods
{
    public class FoodAsterisk : Food
    {
        private const char foodSymbol = '*';
        private const int points = 1;
        public FoodAsterisk(Wall wall)
            : base(wall, foodSymbol, points)
        {
            this.SpeedIncrease = points * -0.1;
        }
    }
}
