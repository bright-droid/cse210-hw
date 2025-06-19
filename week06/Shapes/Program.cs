using System;
using System.Collections.ObjectModel;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square square = new Square("blue", 4);
        shapes.Add(square);

        Rectangle rect = new Rectangle("red", 5, 8);
        shapes.Add(rect);

        Circle circle = new Circle("yellow", 6);
        shapes.Add(circle);

        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();

            double area = shape.GetArea();

            Console.WriteLine($"The {color} shapre has an area of {area}.");
        }
    }
}