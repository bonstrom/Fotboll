using DataTransferObjects;
using EngineNameSpace;
using Identifiers;
using ResourceAccessNameSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerWPF.ViewModel
{
    public class LeagueTableViewModel : ViewModelBase
    {

        #region Construction
        public LeagueTableViewModel(ResourceAccess resourceAccess)
        {
            _resourceAccess = resourceAccess;
        }
        #endregion

        #region Members
        LeagueTable _leagueTable;
        private Guid _selectedSeason;
        private ResourceAccess _resourceAccess;
        #endregion

        #region Properties
        public LeagueTable LeagueTable
        {
            get { return _leagueTable; }
            set
            {
                _leagueTable = value;
                RaisePropertyChanged("LeagueTable");
            }
        }

        public List<ComboBoxItem> Seasons
        {
            get
            {
                return new List<ComboBoxItem> { new ComboBoxItem(Season.PremierLeague_2014_2015, "Premier League 2014-2015"),
                                                    new ComboBoxItem(Season.PremierLeague_2013_2014, "Premier League 2013-2014")};
            }
        }

        public Guid SelectedSeason
        {
            get { return _selectedSeason; }
            set
            {
                _selectedSeason = value;
                LoadTable(_selectedSeason);
            }
        }
        #endregion

        #region Methods
        private void LoadTable(Guid season)
        {
            LeagueTable = _resourceAccess.GetLeagueTable(season);
        }

        #endregion
    }
}
