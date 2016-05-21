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
    public class StryktipsMatches
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

    public class GoldenTicket
    {
        public List<string> result { get; set; }

        public GoldenTicket()
        {
            result = new List<string>();
        }

        public GoldenTicket(List<string> ticket)
        {
            result = ticket;
        }

        public override string ToString()
        {
            return result.Aggregate((current, next) => current + "\n" + next);
        }
    }

    public class StryktipsCoupon
    {
        private StryktipsMatches stryktipsMatches;

        public StryktipsCoupon(StryktipsMatches stryktipsMatches)
        {
            Matches = new CouponRow[13];

            for (int i = 0; i < 13; i++)
                Matches[i] = new CouponRow(stryktipsMatches.matches.match[i], i);
        }

        public CouponRow[] Matches { get; set; }

        public int CouponPrice()
        {
            int cost = 1;
            foreach(var match in Matches)
            {
                int markCounter = 0;
                if (match.One)
                    markCounter++;
                if(match.Cross)
                    markCounter++;
                if(match.Two)
                    markCounter++;
                cost = cost * markCounter;
            }
            return cost;
        }

        public int HalfGuards()
        {
            int halfGuards = 0;
            foreach (var match in Matches)
            {
                int markCounter = 0;
                if (match.One)
                    markCounter++;
                if (match.Cross)
                    markCounter++;
                if (match.Two)
                    markCounter++;
                if (markCounter == 2)
                    halfGuards++;
            }
            return halfGuards;
        }

        public int WholeGuards()
        {
            int wholeGuards = 0;
            foreach (var match in Matches)
            {
                int markCounter = 0;
                if (match.One)
                    markCounter++;
                if (match.Cross)
                    markCounter++;
                if (match.Two)
                    markCounter++;
                if (markCounter == 3)
                    wholeGuards++;
            }
            return wholeGuards;
        }

        public void OrderByLeastPlayed()
        {
          //  var markList = new List<CouponRow>();
            Matches = Matches.OrderBy(m => m.HomeWinBetters < m.DrawBetters && m.HomeWinBetters < m.AwayWinBetters ? m.HomeWinBetters : m.DrawBetters < m.AwayWinBetters ? m.DrawBetters : m.AwayWinBetters).Select(m => m).ToArray();
          //  return markList;
        }

        public void OrderByIndex()
        {
            //  var markList = new List<CouponRow>();
            Matches = Matches.OrderBy(m => m.MatchNumber).ToArray();
            //  return markList;
        }

        public override string ToString()
        {
            return Matches.OrderBy(m => m.MatchNumber).Select(m => m.ToString()).Aggregate((current, next) => current + "\n" + next);
        }
        //return result.Aggregate((current, next) => current + "\n" + next);
    }

    public class CouponRow
    {
        public CouponRow(StryktipsMatches.Match match, int index)
        {
            MatchNumber = index;
            One = false;
            Cross = false;
            Two = false;

            HomeWinBetters = match.HomeWin;
            AwayWinBetters = match.AwayWin;
            DrawBetters = match.Draw;
        }
        public int MatchNumber { get; set; }

        public bool One { get; set; }
        public bool Cross { get; set; }
        public bool Two { get; set; }

        public int HomeWinBetters { get; set; }
        public int DrawBetters { get; set; }
        public int AwayWinBetters { get; set; }

        public override string ToString()
        {
            string rowString = "";
            if (One)
                rowString = "1";
            else
                rowString = " ";

            if (Cross)
                rowString += " X";
            else
                rowString += "  ";

            if (Two)
                rowString += " 2";
            else
                rowString += "  ";

            return rowString;
        }
    }
}
