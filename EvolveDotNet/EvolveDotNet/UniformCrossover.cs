/*
 * Copyright (C) 2012 EvolveDotNet contributors
 * 
 * See CREDITS for information about contributors.
 * 
 * http://code.google.com/p/evolvedotnet/people/list
 * 
 * This file is part of EvolveDotNet C# Framework for Genetic Algorithm.
 *
 * EvolveDotNet is free software: you can redistribute it and/or modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later
 * version.
 * 
 * EvolveDotNet is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied
 * warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more
 * details.
 * 
 * You should have received a copy of the GNU Lesser General Public License along with EvolveDotNet. If not, see
 * <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolveDotNet
{
    class UniformCrossover : ICrossoverMethod
    {
        private double ratePerGene;

        public UniformCrossover()
        {
            this.ratePerGene = 0.5;
        }

        public UniformCrossover(double ratePerGene)
        {
            this.ratePerGene = ratePerGene;
        }
        
        public IList<IGenome> Crossover(IGenome genome1, IGenome genome2)
        {
            IList<bool> offspring1 = new List<bool>();
            IList<bool> offspring2 = new List<bool>();

            for (int i = 0; i < genome1.Length; i++)
            {
                if (Helper.Random.Next() < ratePerGene)
                {
                    offspring1.Add(genome1[i]);
                    offspring2.Add(genome2[i]);
                }
                else
                {
                    offspring1.Add(genome2[i]);
                    offspring2.Add(genome1[i]);
                }
            }

            IList<IGenome> genomes = new List<IGenome>();
            genomes.Add(new BinaryGenome(offspring1));
            genomes.Add(new BinaryGenome(offspring2));
            return genomes;
        }
    }
}

