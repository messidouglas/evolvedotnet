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
    /// Interface to support implementation of several kind of genomes
    /// </summary>
    /// <example>Genome encoded in binary</example>
    public interface IGenome : IComparable<IGenome>, ICloneable
    {
        /// <summary>
        /// Length of genome
        /// </summary>
        int Length { get; }

        /// <summary>
        /// Access each locus of genome
        /// </summary>
        /// <param name="locus">Lower part of genome</param>
        /// <returns>Value this position</returns>
        bool this[int locus] { get; set; }

        /// <summary>
        /// Compare if the Fitness this genome is equal, smaller or larger than Fitness other genome
        /// </summary>
        /// <param name="other">Genome that want to compare with this</param>
        int CompareTo(IGenome other);

        /// <summary>
        /// Calculates the Fitness this genome
        /// </summary>
        double Evaluate();

        /// <summary>
        /// Compare if the value this genome is equal to vaule other genome
        /// </summary>
        void SetFitnessFunction(IFitnessFunction fitnessFunction);
    }
}
