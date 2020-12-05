using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : IDrawable
    {
        private int radius;

        public Circle(int radius)
        {
            this.Radius = radius;
        }

        public int Radius
        {
            get => this.radius;
            private set
            {
                this.radius = value;
            }
        }

        public void Draw()
        {
            double radiusIn = this.radius - 0.4;
            double radiusOut = this.radius + 0.4;

            for (double i = radius; i >= -radius; i--)
            {
                for (double j = -radius; j < radiusOut; j += 0.5)
                {
                    double value = j * j + i * i;

                    if(value >= radiusIn * radiusIn && value <= radiusOut * radiusOut)
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
