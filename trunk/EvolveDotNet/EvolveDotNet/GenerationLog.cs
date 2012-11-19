using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Data;

namespace EvolveDotNet
{
    public class GenerationLog
    {
        private static GenerationLog instance = null;
        private String pathLog;
        private XmlTextWriter xtw;

        private GenerationLog() {

        }

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

        public void Create(String path)
        {
            pathLog = path;
            String fullPath = pathLog + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".xml";
            xtw = new XmlTextWriter(fullPath, Encoding.UTF8);
            xtw.Formatting = Formatting.Indented;
            xtw.Indentation = 4;
        }

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

        public void setStartPopulationLog(int generation)
        {
            xtw.WriteStartElement("Population");
            xtw.WriteAttributeString("Generation", generation.ToString());
        }

        public void setGenomeLog(IGenome genome)
        {
            xtw.WriteStartElement("Genome");
            xtw.WriteAttributeString("Value", genome.ToString());
            xtw.WriteAttributeString("Fitness", genome.Evaluate().ToString());
            xtw.WriteEndElement();
        }

        public void setFinishPopulationLog()
        {
            xtw.WriteEndElement();
        }

    }
}
