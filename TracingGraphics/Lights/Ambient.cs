using TracingGraphics.Utilities;

namespace TracingGraphics.Lights
{
    public class Ambient : Light
    {
        public override Vector3D GetDirection(ref ShadeRec shade)
        {
            return new Vector3D();
        }

        public override RGBColor L(ref ShadeRec shade)
        {
            return Color*Intensity;
        }
    }
}
