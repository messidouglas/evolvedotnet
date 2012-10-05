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
    class BinaryGenome : IGenome
    {
        private IList<bool> genes;
        private int p;

        public BinaryGenome(IList<bool> genes)
        {
            this.genes = genes;
        } 

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

        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
                return false;

            // If parameter cannot be cast to Point return false.
            BinaryGenome genome = obj as BinaryGenome;
            if ((System.Object)genome == null)
                return false;

            // Return false if the fields not match:
            for (int locus = 0; locus != genes.Count; locus++)
            {
                if (genes[locus] != genome.genes[locus])
                    return false;
            }

            // Return true
            return true;
        }

        public override int GetHashCode()
        {
            int hash = 19;
            foreach (bool gene in genes)
                hash = hash * 31 + gene.GetHashCode();

            return hash;
        }

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
        
        public double Evaluate()
        {
            return 0.0;
        }
    }
}
