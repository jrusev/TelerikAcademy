using System;

public class Program
{
    // Refactor the following if statements: 
    //      Potato potato;
    //      //... 
    //      if (potato != null)
    //         if(!potato.HasNotBeenPeeled && !potato.IsRotten)
    //          Cook(potato);
    // //////////////////////////
    //      if (x >= MIN_X && (x =< MAX_X && ((MAX_Y >= y && MIN_Y <= y) && !shouldNotVisitCell)))
    //      {
    //         VisitCell();
    //      }
    public static void Main()
    {
    }

    private static void PreparePotato()
    {
        Potato potato = new Potato();

        // ... 
        if (potato != null && potato.IsPeeled && potato.IsFresh)
        {
            // Cook(potato);
        }
        else
        {
            // TODO: throw three different exceptions for each case
            throw new ApplicationException("Cannot cook potato!");
        }
    }

    private static void CheckCell(int row, int col, int[] matrix, bool isVisited)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        if (row >= 0 && row < rows && col >= 0 && col < cols && !isVisited)
        {
            // VisitCell();
        }
    }

    private class Potato
    {
        public bool IsPeeled { get; set; }

        public bool IsFresh { get; set; }
    }
}
