using System;

public static class Methods
{
    public static double CalcTriangleArea(double a, double b, double c)
    {
        if (a <= 0 || b <= 0 || c <= 0)
        {
            throw new ArgumentException("Sides should be positive!");
        }

        if (a + b <= c || a + c <= b || b + c <= a)
        {
            throw new ArgumentException("Sides cannot form a triangle!");
        }

        double s = (a + b + c) / 2;
        double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        return area;
    }

    public static double CalcDistance(double x1, double y1, double x2, double y2)
    {
        double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        return distance;
    }

    public static bool IsHorizontal(double x1, double y1, double x2, double y2)
    {
        return (y1 == y2);
    }

    public static bool IsVertical(double x1, double y1, double x2, double y2)
    {
        return (x1 == x2);
    }

    public static string FormatAsFloat(object number)
    {
        return string.Format("{0:f2}", number);
    }

    public static string FormatAsPercent(object number)
    {
        return string.Format("{0:p0}", number);
    }

    public static string FormatWithPadding(object number, int padding)
    {
        return number.ToString().PadLeft(padding);
    }

    public static string DigitToText(int digit)
    {
        switch (digit)
        {
            case 0: return "zero";
            case 1: return "one";
            case 2: return "two";
            case 3: return "three";
            case 4: return "four";
            case 5: return "five";
            case 6: return "six";
            case 7: return "seven";
            case 8: return "eight";
            case 9: return "nine";
        }

        throw new ArgumentException("Invalid digit!");
    }

    public static int FindMax(params int[] elements)
    {
        if (elements == null)
        {
            throw new ArgumentNullException("elements");
        }

        if (elements.Length == 0)
        {
            throw new ArgumentException("List of elements in empty");
        }

        int max = elements[0];
        for (int i = 1; i < elements.Length; i++)
        {
            if (elements[i] > max)
            {
                max = elements[i];
            }
        }

        return max;
    }
}
