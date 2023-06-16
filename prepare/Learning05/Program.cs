using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Learning05 World!");
        Square square1 = new Square("blue", 12);
        // Console.WriteLine(square1.GetArea());
        // Console.WriteLine(square1.GetColor());
        

        Rectangle rectangle1 = new Rectangle("green", 5, 13);
        // Console.WriteLine(rectangle1.GetArea());
        // Console.WriteLine(rectangle1.GetColor());

        Circle circle1 = new Circle("yellow", 3);
        // Console.WriteLine(circle1.GetArea());
        // Console.WriteLine(circle1.GetColor());

        List<Shape> list1 = new List<Shape>();

        list1.Add(square1);
        list1.Add(rectangle1);
        list1.Add(circle1);

        foreach(Shape shape in list1){
            Console.WriteLine($"{shape.GetType().Name}");
            Console.WriteLine($"       Color: {shape.GetColor()}");
            Console.WriteLine($"       Area: {shape.GetArea()}");
        }
    }
}