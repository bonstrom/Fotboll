using DataTransferObjects;
using EngineNameSpace;
using ResourceAccessNameSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Identifiers;

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
        private string _matchesAway;
        private string _team;
        public List<Team> Teams { get; protected set; }
        private KeyValuePair<Guid, string> _selectedSeason;
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

        public string MatchesAwayString
        {
            get { return _matchesAway; }
            set
            {
                _matchesAway = value;
                RaisePropertyChanged("MatchesAwayString");
            }
        }

        public List<ComboBoxItem> Seasons
        {
            get
            {
                return new List<ComboBoxItem> { new ComboBoxItem(SeasonMatches.PremierLeague_2014_2015, "Premier League 2014-2015"),
                                                new ComboBoxItem(SeasonMatches.Championship_2014_2015, "Championshit 2014-2015")};
            }
        }

        public KeyValuePair<Guid, string> SelectedSeason
        {
            get { return _selectedSeason; }
            set
            {
                _selectedSeason = value;
                _team = null;
                LoadTeams(_selectedSeason);
            }
        }

        public string Team
        {
            get { return _team; }
            set
            {
                _team = value;
                LoadMatchesHome(new Team(_team), _selectedSeason);
                LoadMatchesAway(new Team(_team), _selectedSeason);
            }
        }
        #endregion

        #region Methods
        public async void LoadMatchesHome(Team team ,KeyValuePair<Guid, string> selectedSeason)
        {
            await Task.Run(() => {
                var matches = _resourceAccess.GetMatchesHome(team, selectedSeason).OrderByDescending(match => match.Date).Take(5);
                MatchesHomeString = string.Join(",\n", matches.Select(o => o.ToString()));
            });
        }

        public async void LoadMatchesAway(Team team, KeyValuePair<Guid, string> selectedSeason)
        {
            await Task.Run(() => {
                var matches = _resourceAccess.GetMatchesAway(team, selectedSeason).OrderByDescending(match => match.Date).Take(5);
                MatchesAwayString = string.Join(",\n", matches.Select(o => o.ToString()));
            });
        }

        private void LoadTeams(KeyValuePair<Guid, string> _selectedSeason)
        {
            Teams = new List<Team>(_engine.GetLeagueTeams(SelectedSeason)).OrderBy(team => team.Name).ToList();
            RaisePropertyChanged("Teams");
        }
        #endregion
    }
}
