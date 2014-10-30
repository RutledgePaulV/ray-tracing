using TracingGraphics.Utilities;

namespace TracingGraphics.Materials
{
    public abstract class Material
    {
        public abstract RGBColor PathShade(ref ShadeRec shade);
        public abstract RGBColor AreaLightShade(ref ShadeRec shade);
        public abstract RGBColor Shade(ref ShadeRec shade);
    }
}
