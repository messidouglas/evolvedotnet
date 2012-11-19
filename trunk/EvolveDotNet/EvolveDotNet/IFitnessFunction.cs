using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolveDotNet
{
    public interface IFitnessFunction
    {
        double Evaluate(IGenome genome);
    }
}
