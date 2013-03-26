using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolveDotNet
{
    /// <summary>
    /// Interface to support implementation of Fitness function
    /// </summary>
    public interface IFitnessFunction
    {
        /// <summary>
        /// Calculates the value of Fitness function
        /// </summary>
        /// <param name="genome">The genome that have calculated the Fitness</param>
        /// <returns>Fitness' value</returns>
        double Evaluate(IGenome genome);
    }
}
