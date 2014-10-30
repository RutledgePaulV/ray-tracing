using System;
using TracingGraphics.Utilities;

namespace TracingGraphics.Samplers
{
    public class Jittered : Sampler
    {
        public Jittered(int _samples, int _sets) : base(_samples,_sets)
        {
           
        }

        public override void GenerateSamples()
        {
            var n = (int) Math.Sqrt(NumberOfSamples);
            var inverse = 1d/n;

            for(var set = 0; set < NumberOfSets; set++)
                for(var x = 0; x < n; x++)
                    for(var y = 0; y < n; y++)
                        Samples.Add(new Point2D((y+Generator.NextDouble())*inverse,(x+Generator.NextDouble())*inverse));
        }
    }
}
