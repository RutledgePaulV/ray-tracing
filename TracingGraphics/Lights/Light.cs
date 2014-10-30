using System;
using TracingGraphics.Utilities;

namespace TracingGraphics.Lights
{
    public abstract class Light
    {
        public bool Shadows;
        public float Intensity;
        public RGBColor Color;

        protected Light()
        {
            Shadows = false;
            Intensity = 1;
            Color = new RGBColor(1);
        }

        public abstract Vector3D GetDirection(ref ShadeRec shade);
        public abstract RGBColor L(ref ShadeRec shade);
    }
}
