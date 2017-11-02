using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarketMath
{
    public class BoxZoning
    {
        public int NumBoxes { get; set; }
        public int LowestValue { get; set; }
        public int HighestValue { get; set; }
        public int Range
        {
            get
            {
                return HighestValue - LowestValue;
            }
        }

        public int GetBoxNumberOf(double value)
        {
            if (value < LowestValue || value > HighestValue)
                return -1;

            double valueCorrected = value - LowestValue;
            double normalizedValue = valueCorrected / Range; //Normalized to range [0, 1] 
            int boxNr = (int)(normalizedValue * NumBoxes);
            return boxNr;
        }
    }
}
