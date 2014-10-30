using System;
namespace TracingGraphics.Utilities
{
    public class Point3D
    {
        public double X, Y, Z;

        public Point3D()
        {
            X = Y = Z = 0;
        }

        public Point3D(ref Point3D point)
        {
            X = point.X;
            Y = point.Y;
            Z = point.Z;
        }

        public Point3D(double value)
        {
            X = Y = Z = value;
        }

        public Point3D(double _x, double _y, double _z)
        {
            X = _x;
            Y = _y;
            Z = _z;
        }

        public static Point3D operator /(Point3D point, double value)
        {
            var inv_value = 1 / value;
            return new Point3D(point.X * inv_value, point.Y * inv_value, point.Z * inv_value);
        }

        public static Point3D operator *(Point3D point, double value)
        {
            return new Point3D(point.X * value, point.Y * value, point.Z * value);
        }

        public static Point3D operator *(double value, Point3D point)
        {
            return new Point3D(point.X * value, point.Y * value, point.Z * value);
        }

        public static Point3D operator +(Point3D point, Vector3D vector)
        {
            return new Point3D(point.X+vector.X,point.Y+vector.Y,point.Z+vector.Z);
        }

        public static Point3D operator -(Point3D point, Vector3D vector)
        {
            return new Point3D(point.X - vector.X, point.Y - vector.Y, point.Z - vector.Z);
        }

        public static Vector3D operator -(Point3D point1, Point3D point2)
        {
            return new Vector3D(point1.X - point2.X, point1.Y - point2.Y, point1.Z - point2.Z);
        }

        public static Point3D operator -(Point3D point)
        {
            return new Point3D(-point.X, -point.Y, -point.Z);
        }

        public Point3D MultiplyConstant(double value)
        {
            return new Point3D(X * value, Y * value, Z * value);
        }

        public Point3D DivideConstant(double value)
        {
            var inv_value = 1 / value;
            return new Point3D(X * inv_value, Y * inv_value, Z * inv_value);
        }

        public Point3D AddVector(Vector3D vector)
        {
            return new Point3D(X + vector.X, Y + vector.Y, Z + vector.Z);
        }

        public Point3D SubtractVector(Vector3D vector)
        {
            return new Point3D(X - vector.X, Y - vector.Y, Z - vector.Z);
        }

        public Vector3D VectorBetween(Point3D point)
        {
            return new Vector3D(X - point.X, Y - point.Y, Z - point.Z);
        }

        public Point3D Negate()
        {
            return new Point3D(-X,-Y,-Z);
        }

        public double DistanceSquared(Point3D point)
        {
            var _x = X - point.X;
            var _y = Y - point.Y;
            var _z = Z - point.Z;
            return _x*_x + _y*_y + _z*_z;
        }

        public double Distance(Point3D point)
        {
            var _x = X - point.X;
            var _y = Y - point.Y;
            var _z = Z - point.Z;
            return Math.Sqrt(_x * _x + _y * _y + _z * _z);
        }
    }
}
