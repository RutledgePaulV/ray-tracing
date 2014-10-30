using System;


namespace TracingGraphics.Utilities
{
    public class Point2D
    {
        public double X, Y;

        public Point2D()
        {
            X = Y = 0;
        }

        public Point2D(ref Point2D point)
        {
            X = point.X;
            Y = point.Y;
        }

        public Point2D(double value)
        {
            X = Y = value;
        }

        public Point2D(double _x, double _y)
        {
            X = _x;
            Y = _y;
        }
    }
}
