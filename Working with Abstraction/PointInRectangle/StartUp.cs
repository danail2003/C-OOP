using System;
using System.Linq;

namespace PointInRectangle
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] sizeOfRectangle = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Point topLeftPoint = new Point(sizeOfRectangle[0], sizeOfRectangle[1]);
            Point bottomRightPoint = new Point(sizeOfRectangle[2], sizeOfRectangle[3]);
            Rectangle rectangle = new Rectangle(topLeftPoint, bottomRightPoint);

            int coordinates = int.Parse(Console.ReadLine());

            for (int i = 0; i < coordinates; i++)
            {
                int[] points = Console.ReadLine().Split().Select(int.Parse).ToArray();
                Point point = new Point(points[0], points[1]);
                Console.WriteLine(rectangle.Contains(point));
            }
        }
    }
}
