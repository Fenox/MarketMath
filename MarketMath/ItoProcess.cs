using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarketMath
{
    public class ItoProcess
    {
        public double CurrentValue { get; set; }

        private Random rand = new Random();

        public double GetNextValue(double deltaTime, Func<double, double, double> a, Func<double, double, double> b)
        {
            double valA = a(CurrentValue, deltaTime) * deltaTime;
            double ValB = b(CurrentValue, deltaTime) * rand.NormalDistributetRandPolarMethod(0, deltaTime);
            double deltaVal = valA + ValB;

            CurrentValue += deltaVal;
            return CurrentValue;
        }
    }
}
