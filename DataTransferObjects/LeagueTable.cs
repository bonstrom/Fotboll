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
            setPositions();
        }

        public LeagueTable()
        {
            Rows = new List<LeagueTableRow>();
            setPositions();
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

            public int Position { get; set; }
            public Team Team { get; set; }
            public int GamesPlayed { get; set; }
            public int Wins { get; set; }
            public int Draw { get; set; }
            public int Losses { get; set; }
            public int GoalsFor { get; set; }
            public int GoalsAgainst { get; set; }
            public int GoalDifference { get { return GoalsFor - GoalsAgainst; } }
            public int Points { get; set; }
        }  
    }
}
