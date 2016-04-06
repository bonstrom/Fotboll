using System;
using System.Collections.Generic;
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
            _rows.AddRange(rows);
        }

        public LeagueTableRow GetTeam(String Name)
        {
            var row = from r in _rows
            where r.Team.Name == Name
            select r;
            return row.FirstOrDefault();
        }

        public class LeagueTableRow
        {
            public int Place { get; set; }
            public Team Team { get; set; }
            public short GamesPlayed { get; set; }
            public short Wins { get; set; }
            public short Draw { get; set; }
            public short Losses { get; set; }
            public short GoalsFor { get; set; }
            public short GoalsAgainst { get; set; }
            public short Points { get; set; }
        }
    }

    
}
