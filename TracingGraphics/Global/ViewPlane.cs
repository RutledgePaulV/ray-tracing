using System;
using TracingGraphics.Samplers;

namespace TracingGraphics.Global
{
    public class ViewPlane
    {
        public int HorizontalResolution { get; set; }
        public int VerticalResolution { get; set; }

        public double PixelSize { get; set; }

        public double Gamma { get; set; }
        public double InverseGamma { get { return 1/Gamma; } }

        public ViewPlane(int horizontal_resolution, int vertical_resolution, float pixel_size)
        {
            HorizontalResolution = horizontal_resolution;
            VerticalResolution = vertical_resolution;
            PixelSize = pixel_size;
            Gamma = 1;
        }
    }
}
