using TracingGraphics.Utilities;

namespace TracingGraphics.Lights
{
    public class PointLight : Light
    {
        public Point3D Location;

        public PointLight(Point3D location)
        {
            Location = location;
        }

        public override Vector3D GetDirection(ref ShadeRec shade)
        {
            return (Location-shade.HitPoint).Normalize();
        }

        public override RGBColor L(ref ShadeRec shade)
        {
            return Color*Intensity;
        }
    }
}
