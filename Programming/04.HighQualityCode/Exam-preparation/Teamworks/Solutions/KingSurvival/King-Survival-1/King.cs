namespace KingSurvival
{
    public class King
    {
        public King()
        {
            this.X = 0;
            this.Y = 0;
        }

        public King(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }
    }
}
