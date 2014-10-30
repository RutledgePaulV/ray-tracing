using TracingGraphics.Global;
using TracingGraphics.Utilities;

namespace TracingGraphics.Tracers
{
    public abstract class Tracer
    {
        public Scene Scene;

        public abstract RGBColor TraceRay(ref Ray ray);

        public abstract RGBColor TraceRay(ref Ray ray, int depth);

        protected Tracer(ref Scene scene)
        {
            Scene = scene;
        }
    }
}
