using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechProg5_5a
{
    public class ConsoleDataProcessor
    {
        private List<TabData> tabDataList = new List<TabData>();

        public void ProcessConsoleData()
        {
            string input = Console.ReadLine();
            int fileNumber = 1;

            while (!string.IsNullOrEmpty(input))
            {
                TabData tabData = ParseTabData(input);
                tabDataList.Add(tabData);

                string fileName = $"G{fileNumber:D4}.dat";
                WriteToFile(fileName, tabData);

                fileNumber++;
                input = Console.ReadLine();
            }
        }

        private TabData ParseTabData(string input)
        {
            string[] parts = input.Split(',');
            double x0 = Convert.ToDouble(parts[0]);
            double xk = Convert.ToDouble(parts[1]);
            int nx = Convert.ToInt32(parts[2]);
            List<double> yValues = new List<double>(Array.ConvertAll(parts[3].Split(' '), double.Parse));

            return new TabData(x0, xk, nx, yValues);
        }

        private void WriteToFile(string fileName, TabData tabData)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                double step = (tabData.Xk - tabData.X0) / tabData.Nx;
                double x = tabData.X0;

                foreach (double y in tabData.YValues)
                {
                    double result = x / Math.Exp(y);
                    writer.WriteLine($"G({x}; {result})");
                    x += step;
                }
            }
        }
    }
}