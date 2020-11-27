
using MathNet.Numerics.Statistics;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class StateMonthMatrix
    {
        public string StateName { get; set; }
        public int JanuarySales { get; set; }
        public int FebruarySales { get; set; }
        public int MarchSales { get; set; }
        public int AprilSales { get; set; }
        public int MaySales { get; set; }
        public int JuneSales { get; set; }
        public int JulySales { get; set; }
        public int AugustSales { get; set; }
        public int SeptemberSales { get; set; }
        public int OctoberSales { get; set; }
        public int NovemberSales { get; set; }
        public int DecemberSales { get; set; }
        public double AverageSales
        {
            get
            {
                double[] months = {
                    JanuarySales,
                    FebruarySales,
                    MarchSales,
                    AprilSales,
                    MaySales,
                    JuneSales,
                    JulySales,
                    AugustSales,
                    SeptemberSales,
                    OctoberSales,
                    NovemberSales,
                    DecemberSales
                };
                if (months.Sum() == 0)
                {
                    return 0;
                }
                else
                {
                    int numToRemove = 0;
                    months = months.Where(val => val != numToRemove).ToArray();
                    return months.Average();
                }
            }
        }
        public double MedianSales
        {
            get
            {
                IEnumerable<double> months = new List<double>()
                {
                    JanuarySales,
                    FebruarySales,
                    MarchSales,
                    AprilSales,
                    MaySales,
                    JuneSales,
                    JulySales,
                    AugustSales,
                    SeptemberSales,
                    OctoberSales,
                    NovemberSales,
                    DecemberSales
                };
                if (months.Sum() == 0)
                {
                    return 0;
                }
                else
                {
                
                    int numToRemove = 0;
                    months = months.Where(val => val != numToRemove);
                    return months.Median();
                }
            }
        }
        public int TotalSales 
        {
            get
            {
                return JanuarySales + FebruarySales + MarchSales + AprilSales + MaySales + JuneSales 
                    + JulySales + AugustSales + SeptemberSales + OctoberSales + NovemberSales + DecemberSales;
            }
        }
    }
}
