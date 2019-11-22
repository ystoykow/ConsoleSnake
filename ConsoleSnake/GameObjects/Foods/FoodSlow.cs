namespace ConsoleSnake.GameObjects.Foods
{
    public class FoodSlow : Food
    {
        private const char foodSymbol = '@';
        private const int points = 1;

        public FoodSlow(Wall wall)
            : base(wall, foodSymbol, points)
        {

            this.SpeedIncrease = points * 2 ;
        }
    }
}
