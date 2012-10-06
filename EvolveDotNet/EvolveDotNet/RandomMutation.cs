using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolveDotNet
{
    class RandomMutation : IMutationMethod
    {
        public double RatePerBit { get; set; }

        public RandomMutation()
        {
            this.RatePerBit = 0.1;
        }

        public RandomMutation(double ratePerBit)
        {
            this.RatePerBit = ratePerBit;
        }

        public void Mutate(IGenome genome)
        {
            if (Helper.Random.NextDouble() < RatePerBit)
            {
                int locus = Helper.Random.Next(genome.Length);
                genome[locus] = !genome[locus];
            }
        }
    }
}
