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
        private List<LeagueTableRow> _rows = new List<LeagueTableRow>();
        public LeagueTable(List<LeagueTableRow> rows)
        {
            _rows.AddRange(rows);
        }

        public LeagueTableRow GetTeam(String Name)
        {
            return _rows.Single(row => row.Team.Name == Name);
        }

        public LeagueTableRow[] GetAllTeams()
        {
            return _rows.ToArray();
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

            public Team Team { get; set; }
            public int GamesPlayed { get; set; }
            public int Wins { get; set; }
            public int Draw { get; set; }
            public int Losses { get; set; }
            public int GoalsFor { get; set; }
            public int GoalsAgainst { get; set; }
            public int Points { get; set; }
        }
    }

    
}
