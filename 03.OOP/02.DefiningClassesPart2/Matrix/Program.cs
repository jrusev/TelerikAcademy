namespace Matrix
{
    using System;

    // Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals). 
    // Implement an indexer this[row, col] to access the inner matrix cells.
    // Implement the operators + and - (addition and subtraction of matrices of the same size) and * for matrix multiplication.
    // Throw an exception when the operation cannot be performed. Implement the true operator (check for non-zero elements).
    public class Program
    {
        public static void Main()
        {
            // Must be of the same size to be able to add and subtract
            int size = 3;
            var mA = new Matrix<int>(size, size);
            var mB = new Matrix<int>(size, size);

            // Populate with random numbers
            Random randomGenerator = new Random();
            for (int i = 0; i < mA.Rows; i++)
            {
                for (int j = 0; j < mA.Cols; j++)
                {
                    mA[i, j] = randomGenerator.Next(15); // [0;15)
                    mB[i, j] = randomGenerator.Next(15); // [0;15)
                }
            }

            // Print the matrices
            Print(mA, '+', mB);
            Print(mA, '-', mB);
            Print(mA, '*', mB);
        }

        private static void Print<T>(Matrix<T> mA, char operation, Matrix<T> mB)
        {
            var mAB = new Matrix<T>(mA.Rows, mB.Cols);
            switch (operation)
            {
                case '+':
                    mAB = mA + mB;
                    break;
                case '-':
                    mAB = mA - mB;
                    break;
                case '*':
                    mAB = mA * mB;
                    break;
            }

            int cellSize = 3;
            for (int row = 0; row < 3; row++)
            {
                string matrixStingA = string.Empty;
                string matrixStingB = string.Empty;
                string matrixStingC = string.Empty;
                for (int col = 0; col < 3; col++)
                {
                    matrixStingA += (col == 0 ? "|" : string.Empty) + Convert.ToString(mA[row, col]).PadLeft(cellSize, ' ') + (col == mA.Cols - 1 ? "|" : " ");
                    matrixStingB += (col == 0 ? "|" : string.Empty) + Convert.ToString(mB[row, col]).PadLeft(cellSize, ' ') + (col == mB.Cols - 1 ? "|" : " ");
                    matrixStingC += (col == 0 ? "|" : string.Empty) + Convert.ToString(mAB[row, col]).PadLeft(cellSize, ' ') + (col == mAB.Cols - 1 ? "|" : " ");
                }

                string op = " " + operation.ToString() + " ";
                Console.WriteLine(matrixStingA + (row == 1 ? op : "   ") + matrixStingB + (row == 1 ? " = " : "   ") + matrixStingC);
            }

            Console.WriteLine();
        }
    }
}
