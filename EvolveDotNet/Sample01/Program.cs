using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EvolveDotNet;

namespace Sample01
{
    public class Program
    {
        private static GenerationLog log = GenerationLog.Instance;

        static void Main(string[] args)
        {
            // população
            // mutação
            // crossover
            // run

            ISelectionFunction sFunc = new TournamentSelection();
            IMutationMethod mut = new RandomMutation(0.05);
            ICrossoverMethod cross = new PointCrossover(1,3);
            DefaultParameter.genomeSize = 10;
            IFitnessFunction fFunc = new FitnessFunction();
            IPopulation pop = new Population(fFunc,sFunc, cross, mut, 10);
            log.Create("../../Logs/");
            //log.setPopulationLog(pop, 1, 100);

            Console.WriteLine("Genome\tFitness");
            for (int i = 0; i < pop.Length; i++)
            {
                Console.WriteLine("{0}\t{1}",pop[i],pop[i].Evaluate());
            }

            int count = 0;
            while (count < 200)
            {
                pop.NextGeneration();
                //log.setPopulationLog(pop, count+2, 100);
                log.setStartPopulationLog(count+1);
                Console.WriteLine("#{0}: Genome\tFitness",count+1);
                for (int i = 0; i < pop.Length; i++)
                {
                    Console.WriteLine("{0}\t{1}", pop[i], pop[i].Evaluate());
                    log.setGenomeLog(pop[i]);
                }
                log.setFinishPopulationLog();
                count++;
            }
            Console.ReadKey();
        }
    }
}
