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
    public enum StopFunction
    {
        FINISH, 

    }
    
    /// <summary>
    /// Parameters used to genetic algorithm
    /// </summary>
    public static class DefaultParameter
    {
        public static int genomeSize = 5;
        public static IInitialPopulationMethod initialPopulation = new ComplementaryGeneration();
        public static ISelectionFunction selection = new TournamentSelection();
        public static ICrossoverMethod crossover = new PointCrossover();
        public static IMutationMethod mutation = new RandomMutation();
        public static bool elitism = true;

        public static StopFunction stopFunction = StopFunction.FINISH | StopFunction.FINISH;

        // Stop Methods
        public static bool Objetive = false;
        public static bool GenerationCount = false;
        public static bool StabilizeGenerationCount = false;
        public static bool DivergenceResetHalf = false;
    }
}
