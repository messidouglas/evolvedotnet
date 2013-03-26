using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Data;

namespace EvolveDotNet
{
    /// <summary>
    /// Generated Logs of developing of population during the process
    /// </summary>
    public class GenerationLog
    {
        private static GenerationLog instance = null;
        private String pathLog;
        private XmlTextWriter xtw;

        /// <summary>
        /// Get a unique instance of class
        /// </summary>
        public static GenerationLog Instance
        {
            get 
            {
                if (instance == null)
                {
                    return new GenerationLog();
                }
                return instance; 
            }
        }

        /// <summary>
        /// Create the file which record the population's generation
        /// </summary>
        /// <param name="path">Path of file's register</param>
        public void Create(String path)
        {
            pathLog = path;
            String fullPath = pathLog + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".xml";
            xtw = new XmlTextWriter(fullPath, Encoding.UTF8);
            xtw.Formatting = Formatting.Indented;
            xtw.Indentation = 4;
        }

        /// <summary>
        /// Record each genome of population and some other parameters
        /// </summary>
        /// <param name="population">Population to be record</param>
        /// <param name="generation">Number of generation</param>
        /// <param name="avarageFitness">Avarage fitness of population</param>
        public void setPopulationLog(IPopulation population, int generation, double avarageFitness)
        {
            xtw.WriteStartElement("Population");
            xtw.WriteAttributeString("Generation", generation.ToString());
            xtw.WriteAttributeString("AvarageFitness", avarageFitness.ToString());

            for (int i = 0; i < population.Length; i++)
            {
                xtw.WriteStartElement("Genome");
                xtw.WriteAttributeString("Value", population[i].ToString());
                xtw.WriteAttributeString("Fitness", population[i].Evaluate().ToString());
                xtw.WriteEndElement();
            }
            xtw.WriteEndElement();
        }

        /// <summary>
        /// Start the tag of population
        /// </summary>
        /// <param name="generation">Number of generation</param>
        public void setStartPopulationLog(int generation)
        {
            xtw.WriteStartElement("Population");
            xtw.WriteAttributeString("Generation", generation.ToString());
        }

        /// <summary>
        /// Record a unique genome
        /// </summary>
        /// <param name="genome">genome to be record</param>
        public void setGenomeLog(IGenome genome)
        {
            xtw.WriteStartElement("Genome");
            xtw.WriteAttributeString("Value", genome.ToString());
            xtw.WriteAttributeString("Fitness", genome.Evaluate().ToString());
            xtw.WriteEndElement();
        }

        /// <summary>
        /// Finish the tag of population
        /// </summary>
        public void setFinishPopulationLog()
        {
            xtw.WriteEndElement();
        }

    }
}
