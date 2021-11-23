using System;
using System.Collections.Generic;
using ExoAbstractInterface.Models;

namespace ExoAbstractInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Figure> figures = new List<Figure>();

            Square square = new Square(1, 5, 10);
            Triangle triangle = new Triangle(4, 8, 12, 8);
            Rectangle rectangle = new Rectangle(7, 8, 5, 10);

            Figure test = square.Deform(2, 8);
            Figure test2 = rectangle.Deform(1, 0.5);

            figures.Add(square);
            figures.Add(triangle);
            figures.Add(rectangle);
            figures.Add(test);
            figures.Add(test2);

            foreach(Figure f in figures) f.Print();

        }
    }
}
