using DataTransferObjects;
using EngineNameSpace;
using Identifiers;
using ResourceAccessNameSpace;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SoccerWPF.ViewModel
{
    public class CompareViewModel : ViewModelBase, INotifyPropertyChanged
    {
        #region Construction
        public CompareViewModel(ResourceAccess resourceAccess, Engine engine, KeyValuePair<Guid, string> league)
        {
            _resourceAccess = resourceAccess;
            _engine = engine;
            Teams = new List<Team>(_engine.GetLeagueTeams(league)).OrderBy(team => team.Name).ToList();
            CanExecuteCompare = false;
            CompareCommand = new RelayCommand(ShowCompareMessage);
        }
        #endregion

        #region Members
        private ResourceAccess _resourceAccess;
        Engine _engine;
        private ICommand _compareButtonCommand;
        private bool _canExecuteCompare;
        private string _team1;
        private string _team2;
        private KeyValuePair<Guid, string> _selectedSeason;
        public string _compareText;
        #endregion

        #region Properties
        public List<Team> Teams { get; protected set; }
        public string Team1
        {
            get { return _team1; }
            set
            {
                _team1 = value;
                CanExecuteCompare = Team1 != null && Team2 != null;
            }
        }
        public string Team2
        {
            get { return _team2; }
            set
            {
                _team2 = value;
                CanExecuteCompare = Team1 != null && Team2 != null;
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
                _team1 = null;
                _team2 = null;
                LoadTeams(_selectedSeason);
            }
        }

        public string CompareText
        {
            get { return _compareText; }
            set
            {
                _compareText = value;
                RaisePropertyChanged("CompareText");
            }
        }
        public ICommand CompareCommand
        {
            get
            {
                return _compareButtonCommand;
            }
            set
            {
                _compareButtonCommand = value;
            }
        }
        public bool CanExecuteCompare
        {
            get
            {
                return _canExecuteCompare;
            }
            set
            {
                _canExecuteCompare = value;
                RaisePropertyChanged("CanExecuteCompare");
            }
        }
        #endregion

        #region Methods
        public void ShowCompareMessage()
        {
            List<Match> matches = _engine.GetMatches(new Team(Team1), new Team(Team2), SelectedSeason);
            int homeWin = matches.Where(x => x.Winner != null).Where(x => x.Winner.Name == Team1).Count();
            int draw = matches.Where(x => x.Winner == null).Count();
            int awayWin = matches.Where(x => x.Winner != null).Where(x => x.Winner.Name == Team2).Count();
            CompareText = Team1 + " - " + Team2 + " " + homeWin + "-" + draw + "-" + awayWin + Environment.NewLine;
            foreach (Match match in matches)
            {
                CompareText = CompareText + match + Environment.NewLine;
            }
        }

        private void LoadTeams(KeyValuePair<Guid, string> _selectedSeason)
        {
            Teams = new List<Team>(_engine.GetLeagueTeams(SelectedSeason)).OrderBy(team => team.Name).ToList();
            RaisePropertyChanged("Teams");
        }
        #endregion
    }
}
