using System;

namespace Shapes
{
    public class StartUp
    {
        public static void Main()
        {
            Shape rectangle = new Rectangle(2.2, 3.5);
            Shape circle = new Circle(2.1);

            Console.WriteLine(rectangle.CalculateArea());
            Console.WriteLine(rectangle.CalculatePerimeter());
            Console.WriteLine(rectangle.Draw());

            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine(circle.Draw());
        }
    }
}
