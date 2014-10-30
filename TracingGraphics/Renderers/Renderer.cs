using System;
using System.Windows;
using TracingGraphics.Cameras;
using TracingGraphics.Global;
using System.Windows.Media.Imaging;
using TracingGraphics.Samplers;
using TracingGraphics.Utilities;

namespace TracingGraphics.Renderers
{
    public class Renderer
    {
        public Sampler Sampler { get; set; }
        public Boolean ShowOutOfGamut { get; set; }
        public WriteableBitmap Canvas;

        public Renderer(ref Sampler _sampler)
        {
            Sampler = _sampler;
            Sampler.GenerateSamples();
        }

        public Renderer(ref WriteableBitmap _canvas,ref Sampler _sampler)
        {
            Canvas = _canvas;
            Sampler = _sampler;
            Sampler.GenerateSamples();
        }

        public void Render(ref Scene scene, ref ViewPlane view, ref Camera camera)
        {
           
            var ray = new Ray();
            var depth = 0;
            var sp = new Point2D();
            var pp = new Point2D();
            var pixel = new RGBColor();
            var scale = camera.ExposureTime/Sampler.NumberOfSamples;

            view.PixelSize /= camera.Zoom;
            ray.Origin = camera.Location;

            for(var y = 0; y < view.VerticalResolution; y++)
            {
                for(var x = 0; x < view.HorizontalResolution; x++)
                {
                    pixel = new RGBColor(0);
                    for(var sample = 0; sample < Sampler.NumberOfSamples; sample++)
                    {
                        sp = Sampler.SampleUnitSquare();
                        pp.Y = view.PixelSize*(y - 0.5*view.VerticalResolution + sp.Y);
                        pp.X = view.PixelSize*(x - 0.5*view.HorizontalResolution + sp.X);
                        ray.Direction = (camera.XAxis*pp.X + camera.YAxis*pp.Y + camera.ZAxis*(-camera.PlaneDistance)).Normalize();
                        pixel += scene.Tracer.TraceRay(ref ray, depth);
                    }

                    pixel *= scale;
                    WritePixel(pixel,x,y);
                }
            }
        }


        //thread safe update of back buffer for writeable bitmap
        public void WritePixel(RGBColor color, int x, int y)
        {
            Canvas.Lock();

            unsafe
            {
                var point_back = (int) Canvas.BackBuffer;
                 point_back += y*Canvas.BackBufferStride + x*4;              
                *((int*) point_back) = color.ToArgb();
            }
           
            Canvas.AddDirtyRect(new Int32Rect(x,y,1,1));
            Canvas.Unlock();
        }

    }
}
