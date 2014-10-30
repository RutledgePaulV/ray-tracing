using System.Collections.Concurrent;
using TracingGraphics.Lights;
using TracingGraphics.Renderables;
using TracingGraphics.Tracers;
using TracingGraphics.Utilities;

namespace TracingGraphics.Global
{
    public class Scene
    {
        public RGBColor BackgroundColor;
        public Tracer Tracer;
        public Light Ambient;
        public ConcurrentBag<Light> Lights;
        public ConcurrentBag<GeometricObject> Objects;

        public Scene(RGBColor _background, Light _ambient, ConcurrentBag<Light> _lights, ConcurrentBag<GeometricObject> _objects)
        {
            BackgroundColor = _background;
            var temporary = this;
            Tracer = new RayCaster(ref temporary);
            Ambient = _ambient;
            Lights = _lights;
            Objects = _objects;
        }

        public ShadeRec HitObjects(ref Ray ray)
        {
            var temp = this;
            var shade = new ShadeRec(ref temp);
            var tmin = Constants.KHugeValue;
            var local = new Point3D();
            
            foreach(var obj in Objects)
            {
                var hitFlag = obj.Hit(ref ray, ref tmin, ref shade);
                
                if(hitFlag)
                {
                    shade.HitAnObject = true;
                    shade.Material = obj.Material;
                    shade.HitPoint = ray.Origin + (ray.Direction * tmin);
                    local = shade.LocalHitPoint;
                }
            }

            if(shade.HitAnObject)
            {
                shade.LocalHitPoint = local;
            }

            return shade;
        }
    }
}
