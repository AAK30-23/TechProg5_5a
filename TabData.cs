using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechProg5_5a
{
    public class TabData
    {
        public double X0 { get; set; }
        public double Xk { get; set; }
        public int Nx { get; set; }
        public List<double> YValues { get; set; }

        public TabData(double x0, double xk, int nx, List<double> yValues)
        {
            X0 = x0;
            Xk = xk;
            Nx = nx;
            YValues = yValues;
        }
    }
}
