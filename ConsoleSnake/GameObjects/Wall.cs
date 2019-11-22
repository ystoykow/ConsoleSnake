namespace ConsoleSnake.GameObjects
{
    public class Wall:Point
    {
        private const char WallSymbol = '\u25A0';

        public Wall(int leftX, int topY)
            : base(leftX, topY)
        {
            InitializeWallBorders();
        }

        public bool IsPointOfWall(Point snake)
        {
            return snake.TopY == 0
                   || snake.LeftX == 0
                   || snake.LeftX == this.LeftX - 1
                   || snake.TopY == this.TopY;
        }

        private void InitializeWallBorders()
        {
            SetHorizontalLines(0);
            SetHorizontalLines(this.TopY);
            SetVerticalLines(0);
            SetVerticalLines(this.LeftX-1);
        }

        private void SetHorizontalLines(int topY)
        {
            for (int leftX = 0; leftX <=this.LeftX; leftX++)
            {
                this.Draw(leftX,topY,WallSymbol);
            }
        }

        private void SetVerticalLines(int leftX)
        {
            for (int topY = 0; topY <= this.TopY; topY++)
            {
                this.Draw(leftX, topY, WallSymbol);
            }
        }
    }
}
