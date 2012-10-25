using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EvolveDotNet;

namespace Sample01
{
    public class FitnessFunction : IFitnessFunction
    {
        public double Evaluate(IGenome genome)
        {
            double fitness = 0;
            for (int i = 0; i < genome.Length; i++)
            {
                if (genome[i])
                {
                    fitness += Math.Pow(2, genome.Length - 1 - i);
                }
            }
            return fitness;
        }
    }
}
