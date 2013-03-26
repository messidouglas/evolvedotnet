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
    /// Class implements the  interface 'IMutationMethod'.
    /// This kind of Mutation is called of Uniform.
    /// It change the value of gene for a random gene value based in a rate set as a 
    /// parameter: 'ratePerGene'.
    /// All of genes are analized and for each of them a Random number is generated, so 
    /// according to the rate parameter is decided if this bit will be changed for other 
    /// value or if remains the same.
    /// </summary>
    public class UniformMutation : IMutationMethod
    {
        public double RatePerGene { get; set; }
        private const double RATE_PER_GENE_DEFAULT = 0.5;

        /// <summary>
        /// Builder set 'ratePerGene' with a Default value
        /// </summary>
        public UniformMutation()
        {
            this.RatePerGene = RATE_PER_GENE_DEFAULT;
        }

        /// <summary>
        /// Builder set 'ratePerGene' with a parameter passed by the user
        /// </summary>
        /// <param name="ratePerGene">Likely to happen Mutation</param>
        public UniformMutation(double ratePerGene)
        {
            this.RatePerGene = ratePerGene;
        }

        /// <summary>
        /// Execute Mutation in the genome for reference with based in the rate
        /// </summary>
        /// <param name="genome">Genome</param>
        public void Mutate(IGenome genome)
        {
            for(int locus = 0; locus < genome.Length; locus++)
            {                
                if (Helper.Random.NextDouble() < RatePerGene)
                    genome[locus] = !genome[locus];
            }
        }
    }
}
