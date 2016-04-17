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
    public class MainWindowModel : ViewModelBase
    {
        #region Construction
        public MainWindowModel()
        {
            _resourceAccess = new ResourceAccess();
            _engine = new Engine();
            LeagueTableModel = new LeagueTableViewModel(_resourceAccess);
            CompareModel = new CompareViewModel(_resourceAccess, _engine, LeaguesTables.PremierLeague_2014_2015);
            StryktipsetModel = new StryktipsetViewModel(_resourceAccess, _engine);
        }
        #endregion

        #region Members
        Engine _engine;
        private ResourceAccess _resourceAccess;
        private LeagueTableViewModel _leagueTableModel;
        private CompareViewModel _compareModel;
        private StryktipsetViewModel _stryktipsetModel;
        #endregion

        #region Properties
        public LeagueTableViewModel LeagueTableModel
        {
            get
            {
                return _leagueTableModel;
            }
            set
            {
                _leagueTableModel = value;
            }
        }

        public CompareViewModel CompareModel
        {
            get
            {
                return _compareModel;
            }
            set
            {
                _compareModel = value;
            }
        }
        public StryktipsetViewModel StryktipsetModel
        {
            get
            {
                return _stryktipsetModel;
            }
            set
            {
                _stryktipsetModel = value;
            }
        }
        #endregion

        #region Methods

        #endregion
    }
}
