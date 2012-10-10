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
    public class PointCrossover : ICrossoverMethod
    {
        private int[] positions;

        public PointCrossover(params int[] positions)
        {
            if (positions.Length != 0)
            {
                this.positions = positions;
                //é necessário ordenar o vetor
            }
        }

        public IList<IGenome> Crossover(IGenome genome1, IGenome genome2)
        {
            IList<bool> offspring1 = new List<bool>();
            IList<bool> offspring2 = new List<bool>();
            bool aux = true;
            int contParams = 0;
            int atual = positions[contParams];

            for (int locus = 0; locus < genome1.Length; locus++)
            {
                if (positions[contParams] == locus)
                {
                    aux = !aux;
                    contParams++;
                }

                if (aux)
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