using TracingGraphics.Global;
using TracingGraphics.Utilities;

namespace TracingGraphics.Tracers
{
    public class RayCaster : Tracer
    {
        public RayCaster(ref Scene scene) : base(ref scene)
        {

        }

        public override RGBColor TraceRay(ref Ray ray)
        {
            var shade = Scene.HitObjects(ref ray);
            if(shade.HitAnObject)
            {
                shade.Ray = ray;
                return shade.Material.Shade(ref shade);
            }
            else
            {
                return Scene.BackgroundColor;
            }
        }

        public override RGBColor TraceRay(ref Ray ray, int depth)
        {
            return TraceRay(ref ray);
        }

    }
}
