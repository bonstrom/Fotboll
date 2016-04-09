using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public class Match
    {
        public Match(DateTime date, Team homeTeam, Team awayTeam, int homeGoals, int awayGoals)
        {
            Date = date;
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            GoalsHome = homeGoals;
            GoalsAway = awayGoals;
        }

        public DateTime Date { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public int GoalsHome { get; set; }
        public int GoalsAway { get; set; }

        public Team Winner
        {
            get
            {
                if (GoalsHome > GoalsAway)
                {
                    return HomeTeam;
                }
                else if (GoalsHome == GoalsAway)
                {
                    //TODO: Inte särskilt snyggt att retuernera null. Kan behöva en omdesign
                    return null;
                }
                return AwayTeam;
            }
        }

        public override string ToString()
        {
            return String.Format("{0}: {1} - {2} {3} - {4}",
                Date.ToShortDateString(),
                HomeTeam.Name,
                AwayTeam.Name,
                GoalsHome,
                GoalsAway);
        }
    }
}
