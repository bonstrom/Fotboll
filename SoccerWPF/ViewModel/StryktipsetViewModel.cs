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
        }
        #endregion

        #region Members
        private ResourceAccess _resourceAccess;
        Engine _engine;
        private ICommand _stryktipsButtonCommand;
        private string _stryktipsstring;
        private bool _canExecuteStryktipset;
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
                StryktipsCoupon acoupon = _resourceAccess.GetStryktipsCoupon();
                CanExecuteStryktipset = true;
                Stryktipsstring = acoupon.ToString();
            });
            Console.WriteLine("Hämtat");
        }

        #endregion
    }
}
