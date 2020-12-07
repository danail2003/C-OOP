using System;

namespace ClassBoxData
{
    public class StartUp
    {
        public static void Main()
        {
            try
            {
                decimal length = decimal.Parse(Console.ReadLine());
                decimal width = decimal.Parse(Console.ReadLine());
                decimal height = decimal.Parse(Console.ReadLine());

                Box box = new Box(length, width, height);

                Console.WriteLine($"Surface Area - {box.SurfaceArea(length, width, height):f2}");
                Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea(length, width, height):f2}");
                Console.WriteLine($"Volume - {box.Volume(length, width, height):f2}");
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
