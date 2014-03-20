using System;
using System.Text;

class MultiplyPolynomials
{
    static void Main()
    {
        // Write a program to support subtraction and multiplication of polynomials.

        // We will use a special class to easily work with polynomials
        Polynomial polyA = new Polynomial(5, 0, 1); // x^2 + 5
        Polynomial polyB = new Polynomial(-7, 4, 5, -1); // -x^3 + 5x^2 + 4x - 7
        Polynomial diffAB = polyA - polyB;
        Polynomial prodAB = polyA * polyB;

        Console.WriteLine("({0}) - ({1}) = {2}", polyA, polyB, diffAB);
        Console.WriteLine("({0}) * ({1}) = {2}", polyA, polyB, prodAB);
        Console.ReadKey(true);
    }
}

/// <summary>Represents a polynomial as array of its coefficients.</summary>
class Polynomial
{
    private int[] coef;

    public int Degree
    {
        get
        {
            return this.coef.Length;
        }
    }

    // Constructor (from array)
    public Polynomial(params int[] array)
    {
        this.coef = new int[array.Length];
        Array.Copy(array, this.coef, array.Length);
    }

    // Constructor (allocate new by size)
    public Polynomial(int size)
    {
        this.coef = new int[size];
    }

    // Indexer
    private int this[int i]
    {
        // If index is out of range, the array will throw an exception.   
        get { return this.coef[i]; }
        set { this.coef[i] = value; }
    }

    // Addition
    public static Polynomial operator +(Polynomial left, Polynomial right)
    {
        Polynomial result = new Polynomial(Math.Max(left.Degree, right.Degree));

        // Sum the coefficients
        for (int i = 0; i < result.Degree; i++)
            result[i] = (i < left.Degree ? left[i] : 0) + (i < right.Degree ? right[i] : 0);

        return result;
    }

    // Subtraction
    public static Polynomial operator -(Polynomial left, Polynomial right)
    {
        Polynomial result = new Polynomial(Math.Max(left.Degree, right.Degree));

        // Subtract the coefficients
        for (int i = 0; i < result.Degree; i++)
            result[i] = (i < left.Degree ? left[i] : 0) - (i < right.Degree ? right[i] : 0);

        return result;
    }

    // Multiplication
    public static Polynomial operator *(Polynomial left, Polynomial right)
    {
        Polynomial result = new Polynomial(left.Degree + right.Degree);

        for (int indLeft = 0; indLeft < left.Degree; indLeft++)
            for (int indRight = 0; indRight < right.Degree; indRight++)
                result[indLeft + indRight] += left[indLeft] * right[indRight];

        return result;
    }

    // Allows printing of the number
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder(this.Degree);

        for (int i = this.Degree - 1; i >= 0; i--)
        {
            int coef = this.coef[i];

            if (coef == 0) continue;

            if (coef == -1) sb.Append('-');
            else if (coef != 1)
            {
                if (i == this.Degree - 1) sb.Append(coef);
                else sb.Append(coef.ToString("+#;-#;0")); // Force a plus (+) sign
            }

            if (i == 1) sb.Append("x");
            else if (i > 1) sb.Append("x^" + i);
        }
        return sb.ToString();
    }
}