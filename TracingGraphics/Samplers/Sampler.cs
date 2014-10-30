using System;
using System.Collections.Generic;
using TracingGraphics.Utilities;

namespace TracingGraphics.Samplers
{
    public abstract class Sampler
    {

        public Random Generator;
        public int NumberOfSets;
        
        private int number_of_samples;
        public int NumberOfSamples
        {
            get { return number_of_samples; }
            set{number_of_samples = (int)Math.Pow((int)Math.Sqrt(value),2);}
        }

       
        public List<Point2D> Samples;
        public long Count;
        public int Jump;

        protected Sampler(int _samples, int _sets)
        {
            NumberOfSamples = _samples;
            NumberOfSets = _sets;
            Generator = new Random(System.DateTime.Now.Millisecond);
            Samples = new List<Point2D>();
            Count = Jump = 0;
        }

        public Point2D SampleUnitSquare()
        {
            if (Count % number_of_samples == 0)
                Jump = Generator.Next(NumberOfSets)*number_of_samples;
            return Samples[Jump + (int) (Count++%number_of_samples)];
        }

        public abstract void GenerateSamples();
    }
}
