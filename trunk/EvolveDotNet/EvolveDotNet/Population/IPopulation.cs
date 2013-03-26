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
    /// Interface to support implementation of populations
    /// </summary>
    public interface IPopulation
    {
        /// <summary>
        /// Access each genome of population
        /// </summary>
        /// <param name="genome">index of genome in the population</param>
        /// <returns>the genome with the corresponding index</returns>
        IGenome this[int genome] { get; set; }

        /// <summary>
        /// Creates a new generation based in set parameters, and so it replace the old
        /// generation.
        /// </summary>
        void NextGeneration();
        
        /// <summary>
        /// Do the crossover according to the type set
        /// </summary>
        /// <param name="genome1">genome 1</param>
        /// <param name="genome2">genome 2</param>
        /// <returns>Two new genomes after the crossover</returns>
        IList<IGenome> Crossover(IGenome genome1, IGenome genome2);

        /// <summary>
        /// Return the size of population
        /// </summary>
        int Length { get; }
    }
}
