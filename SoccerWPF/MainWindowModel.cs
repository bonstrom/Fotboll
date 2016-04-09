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

namespace SoccerWPF
{
    public class LeagueTableViewModel : INotifyPropertyChanged
    {
        #region Construction
        public LeagueTableViewModel()
        {
            _resourceAccess = new ResourceAccess();
            _engine = new Engine();
            Teams = new List<Team>(_engine.GetPremierLeagueTeams());
            CanExecute = true;
            CompareCommand = new RelayCommand(ShowCompareMessage, param => CanExecute);
        }
        #endregion

        #region Members
        LeagueTable _leagueTable;
        Engine _engine;
        private Guid _selectedSeason;
        private ResourceAccess _resourceAccess;
        private ICommand _compareButtonCommand;
        public event PropertyChangedEventHandler PropertyChanged;
        public string _compareText;
        #endregion

        #region Properties
        public LeagueTable LeagueTable {
            get { return _leagueTable; }
            set {
                _leagueTable = value;
                RaisePropertyChanged("LeagueTable");
            }
        }

        public List<Team> Teams { get; protected set; }

        public List<ComboBoxItem> Seasons
        {
            get { return new List<ComboBoxItem> { new ComboBoxItem(Season.PremierLeague_2014_2015, "Premier League 2014-2015"),
                                                    new ComboBoxItem(Season.PremierLeague_2013_2014, "Premier League 2013-2014")}; }
        }

        public Guid SelectedSeason
        {
            get { return _selectedSeason; }
            set {
                _selectedSeason = value;
                loadTable(_selectedSeason);
            }
        }

        public string Team1 { get; set; }
        public string Team2 { get; set; }
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
        public bool CanExecute { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Skickar en notifiering till GUI:t att refresha den ändrade Propertyn
        /// </summary>
        /// <param name="propertyName"></param>
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void loadTable(Guid season)
        {
            LeagueTable = _resourceAccess.GetLeagueTable(season);
        }

        public void ShowCompareMessage(object obj)
        {
            List<Match> matches = _engine.GetMatches(new Team(Team1), new Team(Team2));
            int homeWin = matches.Where(x=>x.Winner != null).Where(x=>x.Winner.Name == Team1).Count();
            int draw = matches.Where(x => x.Winner == null).Count();
            int awayWin = matches.Where(x => x.Winner != null).Where(x => x.Winner.Name == Team2).Count();
            CompareText = Team1 + " - " + Team2 + " " + homeWin + "-" + draw + "-" + awayWin + Environment.NewLine;
            foreach (Match match in matches)
            {
                CompareText = CompareText + match + Environment.NewLine;
            }
            
        }
        #endregion
    }
}
