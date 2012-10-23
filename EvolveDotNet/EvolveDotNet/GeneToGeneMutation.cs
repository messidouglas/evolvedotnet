﻿/*
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
    public class GeneToGeneMutation : IMutationMethod
    {
        public double RatePerBit { get; set; }

        public GeneToGeneMutation(double ratePerBit)
        {
            this.RatePerBit = ratePerBit;
        }

        public void Mutate(IGenome genome)
        {
            for(int locus = 0; locus < genome.Length; locus++)
            {                
                if (Helper.Random.NextDouble() < RatePerBit)
                    genome[locus] = !genome[locus];
            }
        }
    }
}