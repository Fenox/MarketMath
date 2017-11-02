using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MarketSimulator
{
    public class MainViewModel
    {
        public IList<DataPoint> Points { get; set; }



        public MainViewModel()
        {
            this.Points = new List<DataPoint>();

            //double S = 100;
            //double sigma = 0.1;
            //double erwartugnswert = 1;
            //double timeStepSize = 1;

            //Random rand = new Random(10);

            //for (int i = 0; i < 100; i++)
            //{
            //    S = erwartugnswert * S * timeStepSize + sigma * S * (rand.NextDouble() - 0.5);


            //    Points.Add(new DataPoint(i, S));
            //}



        }
    }
}
