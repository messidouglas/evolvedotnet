using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolveDotNet
{
    class FlipGeneMutation : IMutationMethod
    {
        public void Mutate(IGenome genome)
        {
            for (int locus = 0; locus < genome.Length; locus++)
                genome[locus] = !genome[locus];
        }
    }
}
