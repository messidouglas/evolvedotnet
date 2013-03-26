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
    public class BinaryGenome : IGenome
    {
        private IList<bool> genes;
        private IFitnessFunction fitnessFunction;

        /// <summary>
        /// Builder a new genome from a list of genes
        /// </summary>
        /// <param name="genes">List of genes which forms a Genome</param>
        public BinaryGenome(IList<bool> genes)
        {
            this.genes = genes;
        }

        /// <summary>
        /// Builder a new genome from other Binary Genome
        /// </summary>
        /// <param name="binaryGenome">Binary Genome</param>
        public BinaryGenome(BinaryGenome binaryGenome)
        {
            this.genes = binaryGenome.genes;
            this.fitnessFunction = binaryGenome.fitnessFunction;
        }

        /// <summary>
        /// Builder a new genome from length of Genome
        /// </summary>
        /// <param name="length">Amount of locus of Genome</param>
        public BinaryGenome(int length)
        {
            genes = new List<bool>();
            for (int locus = 0; locus < length; locus++)
            {
                genes.Add(Helper.Random.Next(2) == 0 ? false : true);
            }
        }
        
        public bool this[int locus]
        {
            get { return genes[locus]; }
            set { genes[locus] = value; }
        }

        public int Length
        {
            get { return this.genes.Count; }
        }

        /// <summary>
        /// Compare if the value this genome is equal to other genome
        /// </summary>
        /// <param name="obj">The genome to compare with this</param>
        /// <returns>if the genomes are equal or not</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            BinaryGenome genome = obj as BinaryGenome;
            if ((System.Object)genome == null)
                return false;

            for (int locus = 0; locus != genes.Count; locus++)
                if (genes[locus] != genome.genes[locus])
                    return false;

            return true;
        }

        public override int GetHashCode()
        {
            int hash = 19;
            foreach (bool gene in genes)
                hash = hash * 31 + gene.GetHashCode();

            return hash;
        }

        /// <summary>
        /// Print the values of each locus of genome
        /// </summary>
        /// <returns>Values of genome in a string</returns>
        public override string ToString()
        {
            StringBuilder output = new StringBuilder(genes.Count);
            foreach (bool gene in genes)
                output.Append(gene ? "1" : "0");

            return output.ToString();
        }

        public int CompareTo(IGenome other)
        {
            //if this is the smaller genome 
            if (Evaluate() < other.Evaluate())
                return -1;

            // else if this is the biggest genome   
            else if (Evaluate() > other.Evaluate())
                return 1;

            // otherwise they are equal
            else
                return 0;
        }

        /// <summary>
        /// Calculates the Fitness this genome based in the FitnessFunction implements
        /// </summary>
        /// <returns>Value of the Fitness Genome</returns>
        public double Evaluate()
        {
            return fitnessFunction.Evaluate(this);
        }

        /// <summary>
        /// Set Fitness Function in the Genome
        /// </summary>
        /// <param name="fitnessFunction">Class Implements in the Code of user</param>
        public void SetFitnessFunction(IFitnessFunction fitnessFunction)
        {
            this.fitnessFunction = fitnessFunction;
        }

        /// <summary>
        /// Create a identical Genome with other memory address
        /// </summary>
        /// <returns>A copy of genome passed in the parameters</returns>
        public object Clone()
        {
            BinaryGenome newGenome = new BinaryGenome(genes.Count);
            for (int i = 0; i < genes.Count; i++)
                newGenome[i] = genes[i];

            newGenome.fitnessFunction = this.fitnessFunction;

            return newGenome;
        }
    }
}
