using TracingGraphics.Materials;
using TracingGraphics.Utilities;

namespace TracingGraphics.Renderables
{
    public abstract class GeometricObject
    {
        public Material Material;
        public abstract bool Hit(ref Ray ray, ref double tmin, ref ShadeRec shade);
    }
}
