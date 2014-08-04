using Labyrinth;

public class Position
{
    public Position()
    {
        this.X = 3;
        this.Y = 3;
    }

    public Position(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public int X { get; private set; }

    public int Y { get; private set; }

    public bool Move(Direction direction)
    {
        if (this.IsWinning())
        {
            return false;
        }

        switch (direction)
        {
            case Direction.Left:
                this.X -= 1;
                break;
            case Direction.Up:
                this.Y -= 1;
                break;
            case Direction.Right:
                this.X += 1;
                break;
            case Direction.Down:
                this.Y += 1;
                break;
            default:
                return false;
        }

        return true;
    }

    public bool IsWinning()
    {
        bool result;
        result = false;
        if (this.X == 0 || this.X == 6 || this.Y == 0 || this.Y == 6)
        {
            result = true;
        }

        return result;
    }

    public bool IsValidPosition()
    {
        if (this.X <= 6 && this.X >= 0 && this.Y >= 0 && this.Y <= 6)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void MakeStarting()
    {
        this.X = 3;
        this.Y = 3;
    }
}