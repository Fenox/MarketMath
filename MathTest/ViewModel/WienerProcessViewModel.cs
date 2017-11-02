using GalaSoft.MvvmLight;
using MarketMath;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathTest
{
    public class WienerProcessViewModel : ViewModelBase, IControlViewModel
    {
        public string Name
        {
            get
            {
                return "Wiener Process";
            }
        }

        public IList<DataPoint> Points { get; set; } = new List<DataPoint>();

        public WienerProcessViewModel()
        {
            WienerProzess wp = new WienerProzess();
            
            for(int i = 0; i < 10000; i++)
            {
                double nextValue = wp.GetNextValue(1);
                Points.Add(new DataPoint(i, nextValue));
            }
        }
    }
}
