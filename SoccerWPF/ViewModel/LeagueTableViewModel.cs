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
        private KeyValuePair<Guid, string> _selectedSeason;
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
                return new List<ComboBoxItem> { new ComboBoxItem(LeaguesTables.PremierLeague_2014_2015, "Premier League 2014-2015"),
                                                new ComboBoxItem(LeaguesTables.Championship_2014_2015, "Championshit 2014-2015")};
            }
        }

        public KeyValuePair<Guid, string> SelectedSeason
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
        private void LoadTable(KeyValuePair<Guid, string> season)
        {
            LeagueTable = _resourceAccess.GetLeagueTable(season);
        }

        #endregion
    }
}
