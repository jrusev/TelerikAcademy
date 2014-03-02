namespace GeometryAPI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class AdvancedFigureController : FigureController
    {
        public override void ExecuteFigureCreationCommand(string[] splitFigString)
        {
            switch (splitFigString[0])
            {
                case "circle":
                    {
                        // (centerX,centerY,centerZ) radius
                        Vector3D center = Vector3D.Parse(splitFigString[1]);
                        double radius = double.Parse(splitFigString[2]);
                        this.currentFigure = new Circle(center, radius);
                        break;
                    }

                case "cylinder":
                    {
                        // (bottomX,bottomY,bottomZ) (topX, topY, topZ) radius
                        Vector3D bottom = Vector3D.Parse(splitFigString[1]);
                        Vector3D top = Vector3D.Parse(splitFigString[2]);
                        double radius = double.Parse(splitFigString[3]);
                        this.currentFigure = new Cylinder(bottom, top, radius);
                        break;
                    }
            }

            base.ExecuteFigureCreationCommand(splitFigString);
        }

        protected override void ExecuteFigureInstanceCommand(string[] splitCommand)
        {
            switch (splitCommand[0])
            {
                case "area":

                    if (this.currentFigure is IAreaMeasurable)
                    {
                        Console.WriteLine("{0:0.00}", (this.currentFigure as IAreaMeasurable).GetArea());
                    }
                    else
                    {
                        Console.WriteLine("undefined");
                    }

                    break;
                case "normal":

                    if (this.currentFigure is IFlat)
                    {
                        Console.WriteLine("{0:0.00}", (this.currentFigure as IFlat).GetNormal());
                    }
                    else
                    {
                        Console.WriteLine("undefined");
                    }

                    break;
                case "volume":

                    if (this.currentFigure is IVolumeMeasurable)
                    {
                        Console.WriteLine("{0:0.00}", (this.currentFigure as IVolumeMeasurable).GetVolume());
                    }
                    else
                    {
                        Console.WriteLine("undefined");
                    }

                    break;
            }

            base.ExecuteFigureInstanceCommand(splitCommand);
        }
    }
}