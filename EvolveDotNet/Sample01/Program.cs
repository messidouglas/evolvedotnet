using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EvolveDotNet;

namespace Sample01
{
    public class Program
    {
        static void Main(string[] args)
        {
            ISelectionFunction sFunc = new TournamentSelection();
            IMutationMethod mut = new RandomMutation(0.05);
            ICrossoverMethod cross = new PointCrossover(1,3);
            DefaultParameter.genomeSize = 10;
            IFitnessFunction fFunc = new FitnessFunction();
            IPopulation pop = new Population(fFunc,sFunc, cross, mut, 10);


            Console.WriteLine("Genome\tFitness");
            for (int i = 0; i < pop.Length; i++)
            {
                Console.WriteLine("{0}\t{1}",pop[i],pop[i].Evaluate());
            }

            int count = 0;
            while (count < 200)
            {
                pop.NextGeneration();
                Console.WriteLine("#{0}: Genome\tFitness",count+1);
                for (int i = 0; i < pop.Length; i++)
                {
                    Console.WriteLine("{0}\t{1}", pop[i], pop[i].Evaluate());
                }
                count++;
            }
            Console.ReadKey();
        }
    }
}
