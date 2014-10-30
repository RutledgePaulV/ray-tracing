using System;
using TracingGraphics.Global;
using TracingGraphics.Materials;

namespace TracingGraphics.Utilities
{
    public class ShadeRec
    {
        public Boolean HitAnObject;
        public Material Material;
        public Point3D HitPoint;
        public Point3D LocalHitPoint;
        public Vector3D Normal;
        public RGBColor Color;
        public Ray Ray;
        public int Depth;
        public Vector3D Direction;
        public Scene Scene;
        public float T;

        public ShadeRec(ref Scene scene)
        {
            HitAnObject = false;
            Material = null;
            HitPoint = new Point3D();
            LocalHitPoint = new Point3D();
            Normal = new Vector3D();
            Ray = new Ray();
            Depth = 0;
            Direction = new Vector3D();
            Color = scene.BackgroundColor;
            Scene = scene;
        }
    }
}
