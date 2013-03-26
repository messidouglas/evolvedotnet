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
    /// This a kind of Selection called of Tournament.
    /// It chooses two genomes at random and compare between them which has a
    /// better evaluate through the Fitness Function
    /// </summary>
    public class TournamentSelection : ISelectionFunction
    {
        /// <summary>
        /// Select one genome of population
        /// </summary>
        /// <param name="population">Population with genomes</param>
        /// <returns>The genome chosen</returns>
        public IGenome Select(IPopulation population)
        {
            int genome1 = Helper.Random.Next(0, population.Length);
            int genome2 = Helper.Random.Next(0, population.Length);

            if (population[genome1].CompareTo(population[genome2]) < 0)
                return population[genome2];
            else
                return population[genome1];
        }
    }
}
