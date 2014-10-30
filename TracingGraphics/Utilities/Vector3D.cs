using System;


namespace TracingGraphics.Utilities
{
    public class Vector3D
    {
        public double X, Y, Z;

        public Vector3D()
        {
            X = Y = Z = 0;
        }

        public Vector3D(Vector3D vector)
        {
            X = vector.X;
            Y = vector.Y;
            Z = vector.Z;
        }

        public Vector3D(double value)
        {
            X = Y = Z = value;
        }

        public Vector3D(double _x, double _y, double _z)
        {
            X = _x;
            Y = _y;
            Z = _z;
        }

        public static Vector3D operator *(Vector3D vector, double value)
        {
            return new Vector3D(vector.X*value,vector.Y*value,vector.Z*value);
        }

        public static Vector3D operator *(double value, Vector3D vector)
        {
            return new Vector3D(vector.X * value, vector.Y * value, vector.Z * value);
        }

        public static Vector3D operator /(Vector3D vector, double value)
        {
            var inv_value = 1 / value;
            return new Vector3D(vector.X * inv_value, vector.Y * inv_value, vector.Z * inv_value);
        }

        public static Vector3D operator +(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(vector1.X + vector2.X, vector1.Y + vector2.Y, vector1.Z + vector2.Z);    
        }

        public static Vector3D operator -(Vector3D vector)
        {
            return new Vector3D(-vector.X, -vector.Y, -vector.Z);    
        }

        public static Vector3D operator -(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(vector1.X-vector2.X,vector1.Y-vector2.Y,vector1.Z-vector2.Z);
        }

        public static double operator *(Vector3D vector1, Vector3D vector2)
        {
            return vector1.X*vector2.X + vector1.Y*vector2.Y + vector1.Z*vector2.Z;
        }

        public static Vector3D operator ^(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(
                vector1.Y * vector2.Z - vector1.Z * vector2.Y, 
                vector1.X * vector2.Z - vector1.Z * vector2.X, 
                vector1.X * vector2.Y - vector1.Y * vector2.X
                );
        }

        public Vector3D MultiplyConstant(double value)
        {
            return new Vector3D(X*value,Y*value,Z*value);
        }

        public Vector3D DivideConstant(double value)
        {
            var inv_value = 1/value;
            return new Vector3D(X*inv_value,Y*inv_value,Z*inv_value);
        }

        public Vector3D AddVector(Vector3D vector)
        {
            return new Vector3D(X + vector.X, Y + vector.Y, Z + vector.Z);
        }

        public Vector3D CrossProduct(Vector3D vector)
        {
            return new Vector3D(Y * vector.Z - Z * vector.Y, X * vector.Z-Z * vector.X, X * vector.Y - Y * vector.X);
        }

        public double DotProduct(Vector3D vector)
        {
            return X*vector.X + Y*vector.Y + Z*vector.Z;
        }

        public double Length()
        {
            return Math.Sqrt(X*X + Y*Y + Z*Z);
        }

        public double LengthSquared()
        {
            return X*X + Y*Y + Z*Z;
        }

        public Vector3D Negate()
        {
            return new Vector3D(-X,-Y,-Z);
        }

        public Vector3D Normalize()
        {
            var inv_length = 1/Math.Sqrt(X * X + Y * Y + Z * Z);
            return new Vector3D(X*inv_length, Y*inv_length, Z*inv_length);
        }
    }
}
