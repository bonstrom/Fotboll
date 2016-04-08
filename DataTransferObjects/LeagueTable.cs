using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public class LeagueTable
    {
        private List<LeagueTableRow> _rows;
        public LeagueTable(List<LeagueTableRow> rows)
        {
            Rows = rows;
        }

        public LeagueTable()
        {
            Rows = new List<LeagueTableRow>();
        }

        public List<LeagueTableRow> Rows
        {
            get { return _rows; }
            set
            {
                _rows = value;
                setPositions();
            }
        }

        public LeagueTableRow GetTeam(String Name)
        {
            return Rows.Single(row => row.Team.Name == Name);
        }

        public LeagueTableRow[] GetAllTeams()
        {
            return _rows.ToArray();
        }

        private void setPositions()
        {
            int i = 1;
            _rows = _rows.OrderByDescending(team => team.Points)
                         .ThenByDescending(team => team.GoalDifference)
                         .ThenByDescending(team=>team.GoalsFor)
                         .ThenByDescending(team=>team.Wins)
                         .Select(team => { team.Position = i++; return team; })
                         .ToList();
        }

        public class LeagueTableRow
        {
            public LeagueTableRow(DataRow row)
            {
                Team = new Team((string)row["Team"]);
                GamesPlayed = (int)row["P"];
                Wins = (int)row["W"];
                Draw = (int)row["D"];
                Losses = (int)row["L"];
                GoalsFor = (int)row["F"];
                GoalsAgainst = (int)row["A"];
                Points = (int)row["Pts"];
            }

            public int Position { get; internal set; }
            public Team Team { get; }
            public int GamesPlayed { get; }
            public int Wins { get; }
            public int Draw { get; }
            public int Losses { get; }
            public int GoalsFor { get; }
            public int GoalsAgainst { get; }
            public int GoalDifference { get { return GoalsFor - GoalsAgainst; } }
            public int Points { get; }
        }  
    }
}
