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
    public class BrownianMotionViewModel : ViewModelBase, IControlViewModel
    {
        public RelayCommand UpdateCommand { get; set; }

        public string Name
        {
            get
            {
                return "Brownian Motion";
            }
        }

        public double Drift { get; set; } = 1;

        public double Vola { get; set; } = 10;

        public int Steps { get; set; } = 250;


        BrownianMotion bm = new BrownianMotion();

        public IList<DataPoint> Points { get; set; } = new List<DataPoint>();

        public BrownianMotionViewModel()
        {
            CreateNewBrownianMotion();

            UpdateCommand = new RelayCommand(() => CreateNewBrownianMotion());
        }

        private void CreateNewBrownianMotion()
        {
            Points = new List<DataPoint>();

            bm = new BrownianMotion();
            bm.Drift = Drift;
            bm.Vola = Vola;

            for (int i = 0; i < Steps; i++)
            {
                double nextValue = bm.GetNextValue(1);
                Points.Add(new DataPoint(i, nextValue));
            }

            RaisePropertyChanged("Points");
        }
    }
}
