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

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolveDotNet
{
    /// <summary>
    /// Class implements the interface 'IMutationMethod'.
    /// This kind of Mutation is called of Random.
    /// Using the parameter 'RateMutation' is decided if should happen a mutation or not.
    /// If true, so is chosen a random gene to change its value.
    /// </summary>
    public class RandomMutation : IMutationMethod
    {
        public double RateMutation { get; set; }
        private const double RATE_MUTATION_DEFAULT = 0.1;

        /// <summary>
        /// Builder set 'RateMutation' with a Default value
        /// </summary>
        public RandomMutation()
        {
            this.RateMutation = RATE_MUTATION_DEFAULT;
        }

        /// <summary>
        /// Builder set 'ratePerGene' with a parameter passed by the user
        /// </summary>
        /// <param name="RateMutation">Likely to happen Mutation</param>
        public RandomMutation(double RateMutation)
        {
            this.RateMutation = RateMutation;
        }

        /// <summary>
        /// Execute Mutation in the genome for reference with based in the rate
        /// </summary>
        /// <param name="genome">Genome</param>
        public void Mutate(IGenome genome)
        {
            if (Helper.Random.NextDouble() < RateMutation)
            {
                int locus = Helper.Random.Next(genome.Length);
                genome[locus] = !genome[locus];
            }
        }
    }
}