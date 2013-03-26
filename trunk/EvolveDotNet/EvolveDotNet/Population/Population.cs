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
using EvolveDotNet;

namespace EvolveDotNet
{
    /// <summary>
    /// Controller class of population's generation
    /// </summary>
    public class Population : IPopulation
    {
        private IList<IGenome> population;
        private ISelectionFunction selection;
        private ICrossoverMethod crossover;
        private IMutationMethod mutation;
        private IFitnessFunction fitnessFunction;
        private int generation;
        private double avarageFitness;

        public IFitnessFunction FitnessFunction
        {
            get { return fitnessFunction; }
            set { fitnessFunction = value; }
        }
        
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

        public int Generation
        {
            get { return this.generation; }
            set { this.generation = value; }
        }
        
        public double AvarageFitness
        {
            get { return this.avarageFitness; }
            set { this.avarageFitness = value; }
        }

        public Population(IFitnessFunction fitnessFunction, int size)
        {
//            Log.Create("../../Logs/");
            this.selection = DefaultParameter.selection;
            this.crossover = DefaultParameter.crossover;
            this.mutation = DefaultParameter.mutation;
            this.generation = 1;
            this.avarageFitness = 0;
            this.fitnessFunction = fitnessFunction;

            IInitialPopulationMethod initial = DefaultParameter.initialPopulation;
            this.population = initial.Generate(DefaultParameter.genomeSize, fitnessFunction);
        }

        public Population(IFitnessFunction fitnessFunction, List<IGenome> population)
        {
            //Log.Create("../../Logs/");
            this.selection = DefaultParameter.selection;
            this.crossover = DefaultParameter.crossover;
            this.mutation = DefaultParameter.mutation;
            this.population = population;
        }

        public void NextGeneration()
        {
            IList<IGenome> newGeneration = new List<IGenome>();
            IList<IGenome> aux;
            this.generation++;
            double avarageFitness = 0;

            for (int i = 0; i < this.Length; i+=2)
            {
                aux = this.Crossover(this.selection.Select(this), this.selection.Select(this));
                mutation.Mutate(aux[0]);
                mutation.Mutate(aux[1]);
                newGeneration.Add(aux[0]);
                newGeneration.Add(aux[1]);
                newGeneration[i].SetFitnessFunction(fitnessFunction);
                avarageFitness += newGeneration[i].Evaluate();
                newGeneration[i+1].SetFitnessFunction(fitnessFunction);
                avarageFitness += newGeneration[i+1].Evaluate();
            }

            if (newGeneration.Count > this.Length)
            {
                newGeneration.RemoveAt(this.Length);
            }

            if (DefaultParameter.elitism)
            {
                newGeneration[0] = this.getBest();
            }           

            AvarageFitness = avarageFitness / newGeneration.Count;
            
            this.population = newGeneration;

            //Log.setPopulationLog(this, this.generation, AvarageFitness);
        }
        
        public IList<IGenome> Crossover(IGenome genome1, IGenome genome2)
        {
            return crossover.Crossover(genome1, genome2);
        }
        
        public int Length
        {
            get { return this.population.Count; }
        }

        /// <summary>
        /// Get the best genome based in the fitness' value
        /// </summary>
        /// <returns>the best genome</returns>
        public IGenome getBest()
        {            
            if (this.Length > 0)
            {
                IGenome best = this[0];
                for (int i = 1; i < this.Length; i++)
                {
                    if (this[i].Evaluate() > best.Evaluate())
                        best = this[i];
                }
                return best;
            }
            else
                return null;

        }
    }
}
