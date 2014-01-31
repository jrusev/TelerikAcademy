using System;

class LargestAreaOfElements
{
    // Write a program that finds the largest area of equal neighbor elements in a rectangular matrix and prints its size.

    static int currentArea = 0; // static so it can be modified by DepthFirstSearch() after each recursive call
    static int mark = 0; // used to mark the cells
    static void DepthFirstSearch(int[,] matrix, int row, int col)
    {
        int key = matrix[row, col];
        matrix[row, col] = mark; // visited
        currentArea++;

        // Check the neighbours in each of the four directions (down, right, up, left)
        for (int direction = 0; direction < 4; direction++)
        {
            int currRow = row;
            int currCol = col;
            switch (direction)
            {
                case 0: // down
                    currRow = row + 1;
                    break;
                case 1: // right
                    currCol = col + 1;
                    break;
                case 2: // up
                    currRow = row - 1;
                    break;
                case 3: // left
                    currCol = col - 1;
                    break;
            }
            if (IsInsideMatrix(matrix, currRow, currCol) && matrix[currRow, currCol] == key) DepthFirstSearch(matrix, currRow, currCol);
        }
    }

    static bool IsInsideMatrix(int[,] matrix, int row, int col)
    {
        return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
    }

    static void PrintMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
            for (int col = 0; col < matrix.GetLength(1); col++)
                Console.Write(matrix[row, col] + (col < matrix.GetLength(1) - 1 ? " " : "\n"));
    }

    static int[,] RandomMatrix(int rows, int cols)
    {
        Random rand = new Random();
        int[,] matrix = new int[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = rand.Next(1,5);
            }
        }
        return matrix;
    }

    static void Main()
    {
        int[,] matrix = RandomMatrix(5,6);
        //{
        //    { 1, 3, 2, 2, 2, 4 },
        //    { 3, 3, 3, 2, 4, 4 },
        //    { 4, 3, 1, 2, 3, 3 },
        //    { 4, 3, 1, 3, 3, 1 },
        //    { 4, 3, 3, 3, 1, 1 }
        //};

        //PrintMatrix(matrix);
        int[,] matrixOrg = (int[,])matrix.Clone(); // copy of the original matrix

        // Run Depth-first search (DFS) on each cell
        // Mark every visited cell with '0'
        int maxArea = 0;
        int maxMark = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] > 0) // was not visited
                {
                    currentArea = 0;
                    mark--;
                    DepthFirstSearch(matrix, row, col); // modifies currentArea
                    if (currentArea > maxArea)
                    {
                        maxArea = currentArea;
                        maxMark = mark;
                    }
                }
            }
        }
        Console.WriteLine("The largest area of equal neighbor elements consists of {0} elements:", maxArea);

        // Print the original matrix and highlights the elements with the maximum area
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == maxMark)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    //Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write(matrixOrg[row, col] + (col < matrixOrg.GetLength(1) - 1 ? " " : "\n"));
                Console.BackgroundColor = ConsoleColor.Black;
                //Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}