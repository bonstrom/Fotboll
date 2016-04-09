using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// Autogenererad klass för att mappa Json-string till Objekt
    /// </summary>
    public class StryktipsCoupon
    {
        public Matches matches { get; set; }

        public class Match
        {
            public object Id { get; set; }
            public string HomeTeam { get; set; }
            public string AwayTeam { get; set; }
            public int HomeWin { get; set; }
            public int Draw { get; set; }
            public int AwayWin { get; set; }
        }

        public class Matches
        {
            public List<Match> match { get; set; }
        }

        public override string ToString()
        {
            string str = "";
            foreach(Match match in matches.match)
            {
                str = str + string.Format("{0}. {1} - {2}  {3}%-{4}%-{5}%", 
                    match.Id,
                    match.HomeTeam,
                    match.AwayTeam,
                    match.HomeWin,
                    match.Draw,
                    match.AwayWin) + Environment.NewLine;
            }
            return str;
        }
    }
}
