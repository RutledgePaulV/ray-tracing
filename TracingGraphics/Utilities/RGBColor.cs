using System;
using System.Drawing;

namespace TracingGraphics.Utilities
{
    public class RGBColor
    {
        public float R, G, B;

        public RGBColor()
        {
            R = G = B = 0;
        }

        public RGBColor(float value)
        {
            R = G = B = value;
        }

        public RGBColor(float _r, float _g, float _b)
        {
            R = _r;
            G = _g;
            B = _b;
        }

        public RGBColor(double _r, double _g, double _b)
        {
            R = (float) _r;
            G = (float) _g;
            B = (float) _b;
        }

        public RGBColor(Color color)
        {
            R = color.R/255f;
            G = color.G/255f;
            B = color.B/255f;
        }

        public static RGBColor operator +(RGBColor color1, RGBColor color2)
        {
            return new RGBColor(color1.R+color2.R,color1.G+color2.G,color1.B+color2.B);
        }

        public static RGBColor operator -(RGBColor color1, RGBColor color2)
        {
            return new RGBColor(color1.R-color2.R,color1.G-color2.G,color1.B-color2.B);    
        }

        public static RGBColor operator -(RGBColor color)
        {
            return new RGBColor(-color.R, -color.G, -color.B);
        }

        public static RGBColor operator *(RGBColor color1, RGBColor color2)
        {
            return new RGBColor(color1.R*color2.R,color1.G*color2.G,color1.B*color2.B);
        }

        public static RGBColor operator *(RGBColor color, double value)
        {
            return new RGBColor(color.R*(float)value,color.G*(float)value,color.B*(float)value);
        }

        public static RGBColor operator *(double value, RGBColor color)
        {
            return new RGBColor(color.R * (float)value, color.G *(float)value, color.B *(float)value);
        }

        public static RGBColor operator /(RGBColor color, double value)
        {
            var inv_value = 1/(float)value;
            return new RGBColor(color.R*inv_value, color.G*inv_value, color.B*inv_value);
        }


        public RGBColor AddColor(ref RGBColor color)
        {
            return new RGBColor(R+color.R, G+color.G, B+color.B);
        }

        public RGBColor SubtractColor(ref RGBColor color)
        {
            return new RGBColor(R - color.R, G - color.G, B - color.B);
        }

        public RGBColor MultiplyColor(ref RGBColor color)
        {
            return new RGBColor(R*color.R, G*color.G, B*color.B);    
        }

        public RGBColor MultiplyConstant(float value)
        {
            return new RGBColor(R*value,G*value, B*value);
        }

        public int ToArgb()
        {
            var min = Math.Min(R, Math.Min(G, B));
            
            if(min<0)
            {
                R += min;
                G += min;
                B += min;
            }

            var max = Math.Max(R, Math.Max(G, B));
            
            if(max > 1)
            {
                R /= max;
                G /= max;
                B /= max;
            }

            var r = (int) (R*255);
            var g = (int) (G*255);
            var b = (int) (B*255);
            return (255 << 24) | (r << 16) | (g << 8) | b;
        }

        public Color ToColor()
        {
            return Color.FromArgb((int)Math.Round(255 * R), (int)Math.Round(255 * G), (int)Math.Round(255 * B));
        }
    }
}
