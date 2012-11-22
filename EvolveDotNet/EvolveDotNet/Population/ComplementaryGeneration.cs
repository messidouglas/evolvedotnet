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
    public class ComplementaryGeneration : IInitialPopulationMethod
    {
        public List<IGenome> Generate(int size, IFitnessFunction fitnessFunction)
        {
            List<IGenome> population = new List<IGenome>();
            FlipGeneMutation flip = new FlipGeneMutation();
            
            for (int i = 0; i < size; i+=2)
            {
                population.Add(new BinaryGenome(DefaultParameter.genomeSize));
                population[i].SetFitnessFunction(fitnessFunction);

                IGenome genome = (BinaryGenome)population[i].Clone();
                flip.Mutate(genome);
                population.Add(genome);
                population[i+1].SetFitnessFunction(fitnessFunction);
            }

            return population;
        }
    }
}
