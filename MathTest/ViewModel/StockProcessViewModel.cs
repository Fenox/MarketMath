using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MarketMath;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathTest.ViewModel
{
    public class StockProcessViewModel : ViewModelBase, IControlViewModel
    {
        public RelayCommand UpdateCommand { get; set; }

        public string Name
        {
            get
            {
                return "Stock Process";
            }
        }

        public double Drift { get; set; } = 0.01;

        public double Vola { get; set; } = 0.01;

        public int Steps { get; set; } = 250;

        public int InitialValue { get; set; } = 100;


        StockProcess bm = new StockProcess(100);

        public IList<DataPoint> Points { get; set; } = new List<DataPoint>();

        public StockProcessViewModel()
        {
            CreateStockProcess();

            UpdateCommand = new RelayCommand(() => CreateStockProcess());
        }

        private void CreateStockProcess()
        {
            Points = new List<DataPoint>();

            bm = new StockProcess(InitialValue);
            bm.Drift = Drift;
            bm.Vola = Vola;

            for (int i = 0; i < Steps; i++)
            {
                double nextValue = bm.GetNextPrice(1.0/Steps);
                Points.Add(new DataPoint(i, nextValue));
            }

            RaisePropertyChanged("Points");
        }
    }
}
