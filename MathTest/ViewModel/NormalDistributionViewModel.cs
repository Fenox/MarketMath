using GalaSoft.MvvmLight;
using MarketMath;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathTest
{
    public class NormalDistributionViewModel : ViewModelBase, IControlViewModel
    {
        public IList<ColumnItem> Points { get; set; }

        public string Name
        {
            get
            {
                return "Normal Distribution";
            }
        }

        public NormalDistributionViewModel()
        {
            PlotNormalDistributionOfPolarRandom(100000, 0, 1);
        }
        public void PlotNormalDistributionOfPolarRandom(int numbersToGenerate, double mean, double variance)
        {
            BoxZoning boxHelp = new BoxZoning();
            boxHelp.HighestValue = 2;
            boxHelp.LowestValue = -2;
            boxHelp.NumBoxes = 40;

            Random rand = new Random();
            double[] generatedNumbers = new double[numbersToGenerate];

            for (int i = 0; i < numbersToGenerate; i++)
                generatedNumbers[i] = rand.NormalDistributetRandPolarMethod(mean, variance);

            PlotNumbersInColumns(generatedNumbers, boxHelp);
        }

        private void PlotNumbersInColumns(double[] numbers, BoxZoning zones)
        {
            Points = new List<ColumnItem>();

            int[] results = new int[zones.NumBoxes];
            for (int i = 0; i < numbers.Length; i++)
            {
                double num = numbers[i];

                int boxNr = zones.GetBoxNumberOf(num);
                if (boxNr != -1)
                    results[boxNr]++;
            }

            for (int i = 0; i < results.Length; i++)
            {
                ColumnItem newItem = new ColumnItem();
                newItem.Value = results[i];
                Points.Add(newItem);
            }
        }
    }
}
