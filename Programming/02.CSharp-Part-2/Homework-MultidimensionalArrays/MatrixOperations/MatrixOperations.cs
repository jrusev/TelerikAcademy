using System;

class Matrix
{
    // Write a class Matrix, to hold a matrix of integers.
    // Overload the operators for adding, subtracting and multiplying of matrices,
    // ...indexer for accessing the matrix content and ToString().

    // properties
    private int[,] matrix; // private, so it cannot be modified directly
    private int rows, cols;

    // the rows and cols of the internal matrix array wil be read-only
    public int Rows
    {
        get { return rows; }
    }

    public int Cols
    {
        get { return cols; }
    }

    // indexer accessor
    // see: http://msdn.microsoft.com/en-us/library/2549tw02.aspx
    // we need this to access the elements of the matrix, similar to how we access an array
    public int this[int m, int n]
    {
        // If indexes are out of range, the matrix array will throw an exception.   
        get { return matrix[m, n]; }
        set { matrix[m, n] = value; }
    }

    // To create an empty matrix of size m x n:
    // Matrix a = new Matrix(m, n);
    public Matrix(int m, int n)
    {
        if (m < 0 || n < 0)
        {
            // throw an exception here
        }
        matrix = new int[m, n];
        rows = m;
        cols = n;
    }

    // Addition
    public static Matrix operator +(Matrix A, Matrix B)
    {
        Matrix AB;
        if (A.Rows == B.Rows && A.Cols == B.Cols) // the matrices must be of the same size
        {
            AB = new Matrix(A.Rows, A.Cols);
            for (int i = 0; i < AB.Rows; i++)
                for (int j = 0; j < AB.Cols; j++)
                    AB[i, j] = A[i, j] + B[i, j];
        }
        else
        {
            AB = new Matrix(0, 0); // throw an exception here
        }
        return AB;
    }

    // Subtraction
    public static Matrix operator -(Matrix A, Matrix B)
    {
        Matrix AB;
        if (A.Rows == B.Rows && A.Cols == B.Cols) // the matrices must be of the same size
        {
            AB = new Matrix(A.Rows, A.Cols);
            for (int i = 0; i < AB.Rows; i++)
                for (int j = 0; j < AB.Cols; j++)
                    AB[i, j] = A[i, j] - B[i, j];
        }
        else
        {
            AB = new Matrix(0, 0); // throw an exception here
        }
        return AB;
    }

    // Multiplication
    public static Matrix operator *(Matrix A, Matrix B)
    {
        Matrix AB;
        // the product AB is defined only if the number of columns in A is equal to the number of rows in B
        if (A.Cols == B.Rows)
        {
            AB = new Matrix(A.Rows, B.Cols);
            for (int i = 0; i < AB.Rows; i++)
                for (int j = 0; j < AB.Cols; j++)
                    for (int k = 0; k < A.Cols; k++)
                        AB[i, j] += A[i, k] * B[k, j];
        }
        else
        {
            AB = new Matrix(0, 0); // throw an exception here
        }
        return AB;
    }

    // Console.WriteLine(objectToPrint) calls the ToString method of objectToPrint to produce its string representation.
    // Every object in C# has a built in ToString method, which implicitly gets called in cased like this. 
    // The default implementation returns the fully qualified name of the type of the Object, in this case "Matrix".
    // So to print a meaningful representation of our Matrix class, we need to override the ToString method.
    public override string ToString()
    {
        // find the matrix element with greatest number of digits (including the minus sign)
        // to determine the cell size and properly display the matrix
        int max, min;
        max = min = this.matrix[0, 0];
        foreach (int cell in this.matrix)
        {
            max = Math.Max(max, cell);
            min = Math.Min(min, cell); // we need this for the negative numbers
        }
        int sizeMin = Convert.ToString(min).Length;
        int sizeMax = Convert.ToString(max).Length;
        int cellSize = Math.Max(sizeMin, sizeMax);

        string matrixSting = String.Empty;

        for (int row = 0; row < this.Rows; row++)
            for (int col = 0; col < this.Cols; col++)
                matrixSting += ((col == 0 ? "|" : "") + Convert.ToString(this.matrix[row, col]).PadLeft(cellSize, ' ') + (col == this.Cols - 1 ? "|\n" : " "));

        return matrixSting;
    }
}

class MatrixOperations
{
    static void Main()
    {
        // must be of the same size to be able to add and subtract
        int size = 3;
        Matrix A = new Matrix(size, size);
        Matrix B = new Matrix(size, size);

        // populate with random numbers
        Random randomGenerator = new Random();
        for (int i = 0; i < A.Rows; i++)
        {
            for (int j = 0; j < A.Cols; j++)
            {
                A[i, j] = randomGenerator.Next(15); // [0;15)
                B[i, j] = randomGenerator.Next(15); // [0;15)
            }
        }

        // print the matrices
        Print(A, '+', B);
        Print(A, '-', B);
        Print(A, '*', B);
    }

    static void Print(Matrix A, char operation, Matrix B)
    {
        Matrix AB = new Matrix(A.Rows,B.Cols);
        switch (operation)
        {
            case '+':
                AB = A + B;
                break;
            case '-':
                AB = A - B;
                break;
            case '*':
                AB = A * B;
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
                matrixStingA += ((col == 0 ? "|" : "") + Convert.ToString(A[row, col]).PadLeft(cellSize, ' ') + (col == A.Cols - 1 ? "|" : " "));
                matrixStingB += ((col == 0 ? "|" : "") + Convert.ToString(B[row, col]).PadLeft(cellSize, ' ') + (col == B.Cols - 1 ? "|" : " "));
                matrixStingC += ((col == 0 ? "|" : "") + Convert.ToString(AB[row, col]).PadLeft(cellSize, ' ') + (col == AB.Cols - 1 ? "|" : " "));
            }
            string op = " " + operation.ToString() + " ";
            Console.WriteLine(matrixStingA + (row == 1 ? op : "   ") + matrixStingB + (row == 1 ? " = " : "   ") + matrixStingC);
        }
        Console.WriteLine();
    }
}