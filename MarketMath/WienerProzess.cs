using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarketMath
{
    public class WienerProzess
    {
        Random rand = new Random();
        public double CurrentValue { get; set; }

        public double GetNextValue(double deltaTime)
        {
            CurrentValue += rand.NormalDistributetRandPolarMethod(0, deltaTime);
            return CurrentValue;
        }
    }
}
