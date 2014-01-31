using System;

class InCircleOutRectangle
{
    static void Main()
    {
        // Write an expression that checks if a given point (x, y)
        // is within the circle K( (1,1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2).

        Console.WriteLine("Please enter coordinates of the point:");
        Console.Write("x = ");
        float pointX = float.Parse(Console.ReadLine());
        Console.Write("y = ");
        float pointY = float.Parse(Console.ReadLine());

        float circleX = 1; // center X
        float circleY = 1; // center Y
        float circleRadius = 3; // radius

        float rectangleLeft = -1; // left
        float rectangleTop = 1; // top
        float rectangleRight = rectangleLeft + 6; //  + width
        float rectangleBottom = rectangleTop - 2; // - height

        bool inRectangle = (pointX >= rectangleLeft) && (pointX <= rectangleRight) && (pointY <= rectangleTop) && (pointY >= rectangleBottom);
        bool inCircle = ((pointX - circleX) * (pointX - circleX) + (pointY - circleY) * (pointY - circleY)) <= (circleRadius * circleRadius);
        bool result = inCircle && !inRectangle; // will return True if it is within the circle and outside the rectangle

        if(result)
        {
            Console.WriteLine("The point is within the circle and out of the rectangle");
        }
        else
        {
            Console.WriteLine("The point is not within the circle or outside the rectangle");
        }
    }
}