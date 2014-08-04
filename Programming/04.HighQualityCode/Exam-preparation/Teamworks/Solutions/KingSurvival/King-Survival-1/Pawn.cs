namespace KingSurvival
{
    public class Pawn
    {
        public Pawn()
        {
            this.X = 0;
            this.Y = 0;
        }

        public Pawn(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }
    }
}