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
    public class TeamInfoViewModel : ViewModelBase
    {
        #region Construction
        public TeamInfoViewModel(ResourceAccess resourceAccess, Engine engine)
        {
            _resourceAccess = resourceAccess;
            _engine = engine;
        }
        #endregion

        #region Members
        private ResourceAccess _resourceAccess;
        Engine _engine;
        private string _matchesHome;
        #endregion

        #region Properties
        public string MatchesHomeString
        {
            get { return _matchesHome; }
            set
            {
                _matchesHome = value;
                RaisePropertyChanged("MatchesHomeString");
            }
        }
        #endregion

        #region Methods
        public async void LoadMatchesHome()
        {
            await Task.Run(() => {
                StryktipsCoupon acoupon = _resourceAccess.GetStryktipsCoupon();
                MatchesHomeString = acoupon.ToString();
            });
        }
        #endregion
    }
}
