using System;
using System.Text;

class AddPolynomials
{
    static void Main()
    {
        // Write a method that adds two polynomials. Represent them as arrays of their coefficients.
        // Example: x^2 + 5 = 1x^2 + 0x + 5 -> { 5, 0, 1 }

        // We will use a special class to easily work with polynomials
        Polynomial polyA = new Polynomial(5, 0, 1); // x^2 + 5
        Polynomial polyB = new Polynomial(-7, 4, 5, -1); // -x^3 + 5x^2 + 4x - 7
        Polynomial sumAB = polyA + polyB;

        Console.WriteLine("({0}) + ({1}) = {2}", polyA, polyB, sumAB);
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

    // Indexer
    private int this[int i]
    {
        // If index is out of range, the array will throw an exception.   
        get { return this.coef[i]; }
    }

    // Addition
    public static Polynomial operator +(Polynomial left, Polynomial right)
    {
        int[] result = new int[Math.Max(left.Degree, right.Degree)];

        // Sum the coefficients
        for (int i = 0; i < result.Length; i++)
            result[i] = (i < left.Degree ? left[i] : 0) + (i < right.Degree ? right[i] : 0);

        return new Polynomial(result);
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