using TracingGraphics.Utilities;

namespace TracingGraphics.BRDFs
{
    class Lambertian : BRDF
    {
        public  double DiffuseCoefficient;
        public RGBColor Color;

        public Lambertian()
        {
            DiffuseCoefficient = 0;
            Color = new RGBColor(0);
        }

        public override RGBColor F(ref ShadeRec shade, ref Vector3D _in, ref Vector3D _out)
        {
            return Color*DiffuseCoefficient*Constants.InversePi;
        }

        public override RGBColor Rho(ref ShadeRec shade, ref Vector3D _out)
        {
            return Color*DiffuseCoefficient;
        }
    }
}
