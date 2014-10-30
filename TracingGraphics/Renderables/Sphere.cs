using System;
using TracingGraphics.Utilities;

namespace TracingGraphics.Renderables
{
    public class Sphere : GeometricObject
    {
        public Point3D Center;
        public double Radius;
        
        public Sphere(Point3D center, double radius)
        {
            Center = center;
            Radius = radius;
        }

        public override bool Hit(ref Ray ray, ref double tmin, ref ShadeRec shade)
        {
            var temp = ray.Origin - Center;
            var a = ray.Direction.LengthSquared();
            var b = 2*temp*ray.Direction;
            var c = temp.LengthSquared() - Radius*Radius;
            var disc = b*b - 4*a*c;

            if (disc < 0)
                return false;

            var denominator = 2*a;
            var e = Math.Sqrt(disc);
            var root1 = (-b - e)/denominator;
                
            if(root1 > Constants.KEpsilon)
            {
                tmin = root1;
                var intermediate = ray.Direction*root1;
                shade.Normal = ((temp+intermediate)/Radius).Normalize();
                shade.LocalHitPoint = ray.Origin + intermediate;
                return true;
            }

            var root2 = (-b + e)/denominator;

            if(root2 > Constants.KEpsilon)
            {
                tmin = root2;
                var intermediate = ray.Direction*root2;
                shade.Normal = ((temp+intermediate)/Radius).Normalize();
                shade.LocalHitPoint = ray.Origin + intermediate;
                return true;
            }

            return false;
        }
    }
}
