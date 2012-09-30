using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolveDotNet
{
    class FlipGeneMutation : IMutation
    {
        IGenome Mutate(IGenome genome)
        {
            for (int locus = 0; locus < genome.Length; locus++)
                genome[locus] = !genome[locus];

            return genome;
        }
    }
}
