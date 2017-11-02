using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarketMath;
using OxyPlot.Series;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using MathTest.ViewModel;

namespace MathTest
{
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase contentViewModel;
        List<ViewModelBase> pageViewModels { get; set; } = new List<ViewModelBase>();


        public ICommand ChangePageCommand { get; set; }
        
        
        public MainViewModel()
        {
            pageViewModels.Add(new NormalDistributionViewModel());
            pageViewModels.Add(new WienerProcessViewModel());
            pageViewModels.Add(new BrownianMotionViewModel());
            pageViewModels.Add(new StockProcessViewModel());

            ContentViewModel = pageViewModels[0];

            ChangePageCommand = new RelayCommand<ViewModelBase>(
                      p => ChangeViewModel(p)
                      );
        }

        
        private void ChangeViewModel(ViewModelBase viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            ContentViewModel = PageViewModels
                .FirstOrDefault(vm => vm == viewModel);
        }

        public List<ViewModelBase> PageViewModels
        {
            get
            {
                if (pageViewModels == null)
                    pageViewModels = new List<ViewModelBase>();

                return pageViewModels;
            }
        }

        public ViewModelBase ContentViewModel
        {
            get
            {
                return contentViewModel;
            }
            set
            {
                if (contentViewModel != value)
                {
                    contentViewModel = value;
                    RaisePropertyChanged("ContentViewModel");
                }
            }
        }
    }
}
