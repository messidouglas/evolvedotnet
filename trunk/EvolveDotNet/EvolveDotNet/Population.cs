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
    public class Population : IPopulation
    {
        private IList<IGenome> population;
        private ISelectionFunction selection;
        private ICrossoverMethod crossover;
        private IMutationMethod mutation;
        
        public IGenome this[int genome]
        {
            get { return population[genome]; }
            set { population[genome] = value; }
        }

        public ISelectionFunction Selection
        {
            get { return this.selection; }
            set { this.selection = value; }
        }

        public ICrossoverMethod CrossoverType
        {
            get { return this.crossover; }
            set { this.crossover = value; }
        }

        public IMutationMethod MutationType
        {
            get { return this.mutation; }
            set { this.mutation = value; }
        }
        
        public Population(ISelectionFunction selection, ICrossoverMethod crossover, IMutationMethod mutation, int size)
        {
            this.selection = selection;
            this.crossover = crossover;
            this.mutation = mutation;

            for (int i = 0; i < size; i++)
                this.population.Add(new BinaryGenome(DefaultParameter.genomeSize));
        }

        public Population(ISelectionFunction selection, ICrossoverMethod crossover, IMutationMethod mutation, List<IGenome> population)
        {            
            this.selection = selection;
            this.crossover = crossover;
            this.mutation = mutation;
            this.population = population;
        }

        public void NextGeneration()
        {
            IList<IGenome> newGeneration = new List<IGenome>();
            IList<IGenome> aux;

            for (int i = 0; i < this.Length; i+=2)
            {
                aux = this.Crossover(this.selection.Select(this), this.selection.Select(this));
                mutation.Mutate(aux[0]);
                mutation.Mutate(aux[1]);
                newGeneration.Add(aux[0]);
                newGeneration.Add(aux[1]);
            }

            this.population = newGeneration;
        }
        
        public IList<IGenome> Crossover(IGenome genome1, IGenome genome2)
        {
            return crossover.Crossover(genome1, genome2);
        }

        public int Length
        {
            get { return this.population.Count; }
        }
    }
}
