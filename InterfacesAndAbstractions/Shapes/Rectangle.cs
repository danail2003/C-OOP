using System;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.Height = height;
            this.Width = width;
        }

        public int Width
        {
            get => this.width;
            private set
            {
                this.width = value;
            }
        }

        public int Height
        {
            get => this.height;
            private set
            {
                this.height = value;
            }
        }

        public void Draw()
        {
            DrawLine(this.width, '*', '*');

            for (int i = 1; i < height - 1; i++)
            {
                DrawLine(this.width, '*', ' ');
            }

            DrawLine(this.width, '*', '*');
        }

        public void DrawLine(int width, char end, char mid)
        {
            Console.Write(end);

            for (int i = 1; i < width - 1; i++)
            {
                Console.Write(mid);
            }

            Console.WriteLine(end);
        }
    }
}
