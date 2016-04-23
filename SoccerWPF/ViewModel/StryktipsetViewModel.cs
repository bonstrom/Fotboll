using DataTransferObjects;
using EngineNameSpace;
using ResourceAccessNameSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SoccerWPF.ViewModel
{
    public class StryktipsetViewModel : ViewModelBase
    {
        #region Construction
        public StryktipsetViewModel(ResourceAccess resourceAccess, Engine engine)
        {
            _resourceAccess = resourceAccess;
            _engine = engine;
            CanExecuteStryktipset = true;
            StryktipsCommand = new RelayCommand(LoadStryktipsCoupon);
            StryktipsEvaluate = new RelayCommand(EvaluateStryktipset);
        }
        #endregion

        #region Members
        private ResourceAccess _resourceAccess;
        Engine _engine;
        private ICommand _stryktipsButtonCommand;
        private ICommand _stryktipsButtonEvaluateCommand;
        private string _stryktipsstring;
        private bool _canExecuteStryktipset;
        StryktipsCoupon _acoupon;
        private string _goldenTicket;
        #endregion

        #region Properties

        public string Stryktipsstring
        {
            get { return _stryktipsstring; }
            set
            {
                _stryktipsstring = value;
                RaisePropertyChanged("Stryktipsstring");
            }
        }

        public string StryktipsEvaluation
        {
            get { return _goldenTicket; }
            set
            {
                _goldenTicket = value;
                RaisePropertyChanged("StryktipsEvaluation");
            }
        }

        public ICommand StryktipsCommand
        {
            get
            {
                return _stryktipsButtonCommand;
            }
            set
            {
                _stryktipsButtonCommand = value;
            }
        }

        public ICommand StryktipsEvaluate
        {
            get
            {
                return _stryktipsButtonEvaluateCommand;
            }
            set
            {
                _stryktipsButtonEvaluateCommand = value;
            }
        }

        public bool CanExecuteStryktipset
        {
            get { return _canExecuteStryktipset; }
            set
            {
                _canExecuteStryktipset = value;
                RaisePropertyChanged("CanExecuteStryktipset");
            }
        }
        #endregion

        #region Methods

        public async void LoadStryktipsCoupon()
        {
            CanExecuteStryktipset = false;
            await Task.Run(() => {
                _acoupon = _resourceAccess.GetStryktipsCoupon();
                CanExecuteStryktipset = true;
                Stryktipsstring = _acoupon.ToString();
            });
            Console.WriteLine("Hämtat");
        }

        public async void EvaluateStryktipset()
        {
            GoldenTicket goldenTicket;
            if(_acoupon != null)
                await Task.Run(() => {
                    goldenTicket = _engine.EvaluateStryktipset(_acoupon);
                    StryktipsEvaluation = goldenTicket.ToString();
                });
            
        }
        #endregion
    }
}
