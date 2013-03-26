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
    /// <summary>
    /// Class implements the  interface 'ICrossoverMethod'.
    /// This kind of Crossover is called of Uniform.
    /// It mixes the two genomes received based in a rate set as a parameter: 'ratePerLocus'.
    /// All of genes are analized and for each of them a Random number is generated, so 
    /// according to the rate parameter is decided if this locus will be changed for other 
    /// corresponding gene between genome1 and genome2 or if this gene remains the same.
    /// </summary>
    public class UniformCrossover : ICrossoverMethod
    {
        private double ratePerGene;
        private const double RATE_PER_GENE_DEFAULT = 0.5;

        /// <summary>
        /// Builder set 'ratePerGene' with a Default value
        /// </summary>
        public UniformCrossover()
        {
            this.ratePerGene = RATE_PER_GENE_DEFAULT;
        }

        /// <summary>
        /// Builder set 'ratePerGene' with a parameter passed by the user
        /// </summary>
        /// <param name="ratePerGene">Likely to happen Crossover</param>
        public UniformCrossover(double ratePerGene)
        {
            this.ratePerGene = ratePerGene;
        }

        /// <summary>
        /// Execute crossover between two genomes and return other two genomes mixed
        /// </summary>
        /// <param name="genome1">Genome</param>
        /// <param name="genome2">Genome</param>
        /// <returns>Two new genomes, that are a mixture of genome1 and genome2</returns>
        public IList<IGenome> Crossover(IGenome genome1, IGenome genome2)
        {
            IList<bool> offspring1 = new List<bool>();
            IList<bool> offspring2 = new List<bool>();

            for (int locus = 0; locus < genome1.Length; locus++)
            {
                if (Helper.Random.Next() < ratePerGene)
                {
                    offspring1.Add(genome1[locus]);
                    offspring2.Add(genome2[locus]);
                }
                else
                {
                    offspring1.Add(genome2[locus]);
                    offspring2.Add(genome1[locus]);
                }
            }

            IList<IGenome> genomes = new List<IGenome>();
            genomes.Add(new BinaryGenome(offspring1));
            genomes.Add(new BinaryGenome(offspring2));
            return genomes;
        }
    }
}

