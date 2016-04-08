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
            CompareCommand = new RelayCommand(ShowMessage, param => true);
        }
        #endregion

        #region Members
        LeagueTable _leagueTable;
        Engine _engine;
        private Guid _selectedSeason;
        private ResourceAccess _resourceAccess;
        private ICommand _compareButtonCommand;
        public event PropertyChangedEventHandler PropertyChanged;
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

        public void ShowMessage(object obj)
        {
            Console.WriteLine(obj.ToString());
        }
        #endregion
    }
}
