using System;

namespace ClassBoxData
{
    public class Box
    {
        private decimal length;
        private decimal width;
        private decimal height;

        public Box(decimal length, decimal width, decimal height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public decimal Length
        {
            get => this.length;
            private set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

                this.length = value;
            }
        }

        public decimal Width
        {
            get => this.width;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                this.width = value;
            }
        }

        public decimal Height
        {
            get => this.height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                this.height = value;
            }
        }

        public decimal SurfaceArea(decimal length, decimal width, decimal height)
        {
            decimal surfaceArea = (2 * length * width) + (2 * length * height) + (2 * width * height);

            return surfaceArea;
        }

        public decimal LateralSurfaceArea(decimal length, decimal width, decimal height)
        {
            decimal lateralArea = (2 * length * height) + (2 * width * height);

            return lateralArea;
        }

        public decimal Volume(decimal length, decimal width, decimal height)
        {
            decimal volume = length * width * height;

            return volume;
        }
    }
}
