using System;
using TracingGraphics.BRDFs;
using TracingGraphics.Utilities;

namespace TracingGraphics.Materials
{
    public class Matte : Material
    {
        private Lambertian ambient_brdf;
        private Lambertian diffuse_brdf;

        public double Ka { get { return ambient_brdf.DiffuseCoefficient; } set { ambient_brdf.DiffuseCoefficient = value; } }
        public double Kd { get { return diffuse_brdf.DiffuseCoefficient; } set { diffuse_brdf.DiffuseCoefficient = value; } }
        public RGBColor Cd { get { return ambient_brdf.Color; } set { ambient_brdf.Color = diffuse_brdf.Color = value; } }

        public Matte()
        {
            ambient_brdf = new Lambertian();
            diffuse_brdf = new Lambertian();
        }

        public override RGBColor PathShade(ref ShadeRec shade)
        {
            throw new NotImplementedException();
        }

        public override RGBColor AreaLightShade(ref ShadeRec shade)
        {
            throw new NotImplementedException();
        }

        public override RGBColor Shade(ref ShadeRec shade)
        {
            var vector_out = -shade.Ray.Direction;
            var ambient = shade.Scene.Ambient.L(ref shade);
            var color = ambient_brdf.Rho(ref shade, ref vector_out)*ambient;

            foreach(var light in shade.Scene.Lights)
            {
                var vector_in = light.GetDirection(ref shade);
                var normal_dot_vector_in = shade.Normal*vector_in;

                if (normal_dot_vector_in > 0)
                {
                    var light_color = light.L(ref shade);
                    var temp =diffuse_brdf.F(ref shade, ref vector_out, ref vector_in)*light_color*normal_dot_vector_in;
                    color += temp;
                }
                   
            }
            return color;
        }

    }
}
