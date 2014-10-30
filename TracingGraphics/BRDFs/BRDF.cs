using TracingGraphics.Samplers;
using TracingGraphics.Utilities;

namespace TracingGraphics.BRDFs
{
    public abstract class BRDF
    {
        protected Sampler Sampler;
        public abstract RGBColor F(ref ShadeRec shade, ref Vector3D _in, ref Vector3D _out);
        public abstract RGBColor Rho(ref ShadeRec shade, ref Vector3D _out);
    }
}
