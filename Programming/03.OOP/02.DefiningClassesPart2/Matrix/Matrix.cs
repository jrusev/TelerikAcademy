namespace Matrix
{
    using System;

    // Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals). 
    // Implement an indexer this[row, col] to access the inner matrix cells.
    // Implement the operators + and - (addition and subtraction of matrices of the same size) and * for matrix multiplication.
    // Throw an exception when the operation cannot be performed. Implement the true operator (check for non-zero elements).
    public class Matrix<T>
    {
        private T[,] matrix;

        // Create an empty matrix of size m x n
        public Matrix(int m, int n)
        {
            if (m < 0 || n < 0)
            {
                throw new ArgumentOutOfRangeException("Size of the matrix cannot be negative!");
            }

            this.matrix = new T[m, n];
        }

        public int Rows
        {
            get { return this.matrix.GetLength(0); }
        }

        public int Cols
        {
            get { return this.matrix.GetLength(1); }
        }

        // Indexer accessor
        public T this[int row, int col]
        {
            // If indexes are out of range, the matrix array will throw an exception.   
            get { return this.matrix[row, col]; }
            set { this.matrix[row, col] = value; }
        }

        // Addition
        public static Matrix<T> operator +(Matrix<T> mA, Matrix<T> mB)
        {
            if (mA.Rows != mB.Rows || mA.Cols != mB.Cols)
            {
                throw new ArithmeticException("The matrices must be of the same size!");
            }

            Matrix<T> mAB = new Matrix<T>(mA.Rows, mA.Cols);
            for (int row = 0; row < mAB.Rows; row++)
            {
                for (int col = 0; col < mAB.Cols; col++)
                {
                    mAB[row, col] = mA[row, col] + (dynamic)mB[row, col];
                }
            }

            return mAB;
        }

        // Subtraction
        public static Matrix<T> operator -(Matrix<T> mA, Matrix<T> mB)
        {
            if (mA.Rows != mB.Rows || mA.Cols != mB.Cols)
            {
                throw new ArithmeticException("The matrices must be of the same size!");
            }

            Matrix<T> mAB = new Matrix<T>(mA.Rows, mA.Cols);
            for (int row = 0; row < mAB.Rows; row++)
            {
                for (int col = 0; col < mAB.Cols; col++)
                {
                    mAB[row, col] = mA[row, col] - (dynamic)mB[row, col];
                }
            }

            return mAB;
        }

        // Multiplication
        public static Matrix<T> operator *(Matrix<T> mA, Matrix<T> mB)
        {
            if (mA.Cols != mB.Rows)
            {
                throw new ArithmeticException("The number of columns in A must be equal to the number of rows in B!");
            }

            Matrix<T> mAB = new Matrix<T>(mA.Rows, mB.Cols);
            for (int i = 0; i < mAB.Rows; i++)
            {
                for (int j = 0; j < mAB.Cols; j++)
                {
                    for (int k = 0; k < mA.Cols; k++)
                    {
                        mAB[i, j] += mA[i, k] * (dynamic)mB[k, j];
                    }
                }
            }

            return mAB;
        }

        // True operator (check for non-zero elements)
        public static bool operator true(Matrix<T> m)
        {
            for (int i = 0; i < m.Rows; i++)
            {
                for (int j = 0; j < m.Cols; j++)
                {
                    if (m[i, j].Equals(default(T)))
                    {
                        return false;
                    }                        
                }
            }

            return true;
        }

        // False operator (check for non-zero elements)
        public static bool operator false(Matrix<T> m)
        {
            if (m)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override string ToString()
        {
            // Find the matrix element with greatest number of digits (including the minus sign)
            // to determine the cell size and properly display the matrix
            dynamic max, min;
            max = min = this.matrix[0, 0];
            foreach (T value in this.matrix)
            {
                if (value > max)
                {
                    max = value;
                }

                if (value < min)
                {
                    min = value;
                }
            }

            int sizeMin = Convert.ToString(min).Length;
            int sizeMax = Convert.ToString(max).Length;
            int cellSize = Math.Max(sizeMin, sizeMax);

            string matrixSting = string.Empty;

            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    matrixSting +=
                        (col == 0 ? "|" : string.Empty) +
                        Convert.ToString(this.matrix[row, col]).PadLeft(cellSize, ' ') +
                        (col == this.Cols - 1 ? "|\n" : " ");
                }                    
            }

            return matrixSting;
        }
    }
}