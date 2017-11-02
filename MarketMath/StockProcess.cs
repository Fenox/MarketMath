using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarketMath
{
    public class StockProcess : ItoProcess
    {
        public double Drift { get; set; }
        public double Vola { get; set; }

                
        public StockProcess(double initialStockPrice)
        {
            CurrentValue = initialStockPrice;
        }

        public double GetNextPrice(double deltaTime)
        {
            return GetNextValue(deltaTime, a, b); 
        }

        private double a(double x, double deltaTime)
        {
            return x * Drift;
        }
        private double b(double x, double deltaTime)
        {
            return x * Vola;
        }
    }
}
