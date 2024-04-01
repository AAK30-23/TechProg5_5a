using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechProg5_5a
{
    public class FileWriter
    {
        public static void WriteResultsToFile(string fileName, List<double> results)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var result in results)
                {
                    writer.WriteLine(result);
                }
            }
        }
    }
}
