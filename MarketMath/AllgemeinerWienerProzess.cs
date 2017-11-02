using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarketMath
{
    public class BrownianMotion
    {
        public double Drift { get; set; } = 0;
        public double Vola { get; set; } = 1;

        public double CurrentValue { get; set; } = 0;
        public BrownianMotion() { }

        Random rand = new Random();

        public double GetNextValue(double deltaTime)
        {
            double a = Drift * deltaTime;
            double b = Vola * rand.NormalDistributetRandPolarMethod(0, deltaTime);

            CurrentValue += a + b;

            return CurrentValue;
        }
    }
}
