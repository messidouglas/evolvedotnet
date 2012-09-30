using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolveDotNet
{
    class RandomGeneMutation : IMutation
    {
        IGenome Mutate(IGenome genome)
        {
            if (Helper.Random.NextDouble() < rate)
            {
                int locus = Helper.Random.Next(genome.Length);
                genome[locus] = !genome[locus];
            }

            return genome;
        }
    }
}
