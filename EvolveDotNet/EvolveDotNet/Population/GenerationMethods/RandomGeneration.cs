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
    /// <summary>
    /// Creates a new population based in the size of population and its Fitness Function
    /// </summary>
    public class RandomGeneration : IInitialPopulationMethod
    {
        public List<IGenome> Generate(int size, IFitnessFunction fitnessFunction)
        {
            List<IGenome> population = new List<IGenome>();

            for (int i = 0; i < size; i++)
            {
                population.Add(new BinaryGenome(DefaultParameter.genomeSize));
                population[i].SetFitnessFunction(fitnessFunction);
            }

            return population;
        }
    }
}
