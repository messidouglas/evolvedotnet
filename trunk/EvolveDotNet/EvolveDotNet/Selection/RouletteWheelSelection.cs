using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolveDotNet
{
    /// <summary>
    /// This a kind of Selection called of Roulette Wheel.
    /// It chooses a genome at random using the Fitness function as a weight of choice
    /// </summary>
    class RouletteWheelSelection : ISelectionFunction
    {
        /// <summary>
        /// Select one genome of population
        /// </summary>
        /// <param name="population">Population with genomes</param>
        /// <returns>The genome chosen</returns>
        public IGenome Select(IPopulation population)
        {
            IGenome chosen;
            double tournament = Helper.Random.NextDouble();
            double aux = 0;
            double sum = 0;

            for (int i = 0; i < population.Length; i++)
                sum += population[i].Evaluate();

            for (int i = 0; i < population.Length; i++)
            {
                aux += population[i].Evaluate() / sum;
                if (tournament <= aux)
                {
                    chosen = population[i];
                    return chosen;
                }
            }

            return null;
        }
    }
}
