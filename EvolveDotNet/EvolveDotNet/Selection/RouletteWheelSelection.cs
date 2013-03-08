﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolveDotNet
{
    class RouletteWheelSelection : ISelectionFunction
    {
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
