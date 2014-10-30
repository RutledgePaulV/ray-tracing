namespace TracingGraphics.Utilities
{
    public class Ray
    {
        public Point3D Origin;
        public Vector3D Direction;

        public Ray()
        {
            Origin = new Point3D();
            Direction = new Vector3D();
        }

        public Ray(Ray ray)
        {
            Origin = ray.Origin;
            Direction = ray.Direction;
        }

        public Ray(Point3D point, Vector3D vector)
        {
            Origin = point;
            Direction = vector;
        }
    }
}
