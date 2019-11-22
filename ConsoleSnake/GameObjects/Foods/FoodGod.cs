namespace ConsoleSnake.GameObjects.Foods
{
    public class FoodGod : Food
    {
        private const char foodSymbol = '&';
        private const int points = 5;
        public FoodGod(Wall wall)
            : base(wall, foodSymbol, points)
        {
            this.SpeedIncrease = points * -0.5;
        }
    }
}
