namespace PointInRectangle
{
    public class Rectangle
    {
        public Rectangle(Point topLeft, Point bottomRight)
        {
            this.TopLeft = topLeft;
            this.BottomRight = bottomRight;
        }

        private Point topLeft;
        private Point bottomRight;

        public Point TopLeft
        {
            get { return this.topLeft; }
            set { this.topLeft = value; }
        }

        public Point BottomRight
        {
            get { return this.bottomRight; }
            set { this.bottomRight = value; }
        }

        public bool Contains(Point point)
        {
            return this.TopLeft.X <= point.X && this.BottomRight.X >= point.X && this.TopLeft.Y <= point.Y && this.BottomRight.Y >= point.Y;
        }
    }
}
