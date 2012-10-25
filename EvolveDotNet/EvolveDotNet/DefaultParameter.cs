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

    public static class DefaultParameter
    {
        public static int genomeSize = 5;
        public static StopFunction stopFunction = StopFunction.FINISH;

    }
}
