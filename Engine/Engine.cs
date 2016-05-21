using System;
using ResourceAccessNameSpace;
using DataTransferObjects;
using System.Linq;
using System.Collections.Generic;
using Identifiers;

namespace EngineNameSpace
{
    public class Engine
    {
        ResourceAccess resource = new ResourceAccess();
        public Engine()
        {
            Initialize();
        }

        private void Initialize()
        {
            // CalculateOdds(new Team(), new Team());
        }

        public int CalculateOdds(Team homeTeam, Team awayTeam)
        {
            return 5 + 4 * 3;
        }

        public Team[] GetLeagueTeams(KeyValuePair<Guid, string> league)
        {
            if(league.Key == SeasonMatches.PremierLeague_2014_2015.Key)
                return resource.GetLeagueTeams(LeaguesTables.PremierLeague_2014_2015);

            if (league.Key == SeasonMatches.PremierLeague_2013_2014.Key)
                return resource.GetLeagueTeams(LeaguesTables.PremierLeague_2013_2014);

            if (league.Key == SeasonMatches.PremierLeague_2012_2013.Key)
                return resource.GetLeagueTeams(LeaguesTables.PremierLeague_2012_2013);

            if (league.Key == SeasonMatches.Championship_2014_2015.Key)
                return resource.GetLeagueTeams(LeaguesTables.Championship_2014_2015);

            if (league.Key == SeasonMatches.Championship_2013_2014.Key)
                return resource.GetLeagueTeams(LeaguesTables.Championship_2013_2014);

            if (league.Key == SeasonMatches.Championship_2012_2013.Key)
                return resource.GetLeagueTeams(LeaguesTables.Championship_2012_2013);
     
            else
                return resource.GetLeagueTeams(league);
        }

        public List<Match> GetMatches(Team team1, Team team2, KeyValuePair<Guid, string> season)
        {
            return resource.GetMatches(team1, team2, season);
        }

        public LeagueTable LoadLeagueTable(KeyValuePair<Guid, string> season)
        {
            return resource.GetLeagueTable(season);
        }

        public StryktipsCoupon EvaluateStryktipset(StryktipsMatches stryktipsMatches)
        {
            int COUPONGPRICE = 128;
            int WHOLEGUARDS = 0;
            int HALFGUARDS = 7;

            var stryktipsCoupon = new StryktipsCoupon(stryktipsMatches);
            stryktipsCoupon = GenerateCouponMarks(stryktipsCoupon, COUPONGPRICE);
            //foreach (var match in stryktipsMatches.matches.match)
            //{
            //    var result = EvaluateMatch(match);

            //}
            //Lista med tecken
            List<string> l = new List<string>();
            //Stryktipsraden
            List<string> r = new List<string> { "", "", "", "", "", "", "", "", "", "", "", "","" };

            //Lägg in det tecknet med högst spelfördelning i tipsraden och lägg in övriga tecken i en lista
            foreach (var match in stryktipsMatches.matches.match)
            {
                int home = match.HomeWin;
                int draw = match.Draw;
                int away = match.AwayWin;
                if (home > draw && home > away)
                {
                    r[Convert.ToInt32(match.Id)-1] = "1";
                    l.Add((draw + "").PadLeft(3, '0') + "-" + match.Id + "-d");
                    l.Add((away + "").PadLeft(3, '0') + "-" + match.Id + "-a");
                }
                else if (draw > away)
                {
                    r[Convert.ToInt32(match.Id) - 1] = "X";
                    l.Add((home + "").PadLeft(3, '0') + "-" + match.Id + "-h");
                    l.Add((away + "").PadLeft(3, '0') + "-" + match.Id + "-a");
                }
                else
                {
                    r[Convert.ToInt32(match.Id) - 1] = "2";
                    l.Add((home + "").PadLeft(3, '0') + "-" + match.Id + "-h");
                    l.Add((draw + "").PadLeft(3, '0') + "-" + match.Id + "-d");
                }
            }
            //Sortera listan så lägst fördelning hamnar först
            l.Sort((a, b) =>  a.CompareTo(b));

            int num = 0;
            //Lägg in de lägst spelfördelade tecken i tipsraden
            foreach (string s in l)
            {
                int sum = r[0].Count() * r[1].Count() * r[2].Count() * r[3].Count() *
                    r[4].Count() * r[5].Count() * r[6].Count() * r[7].Count() *
                    r[8].Count() * r[9].Count() * r[10].Count() * r[11].Count() *
                    r[12].Count();

                string[] arr = s.Split('-');
                int match = Convert.ToInt32(arr[1]) - 1;
                string sign = arr[2].Equals("h") ? "1" : arr[2].Equals("d") ? "X" : "2";
                r[match] = r[match] + sign;
                sum = r[0].Count() * r[1].Count() * r[2].Count() * r[3].Count() *
                    r[4].Count() * r[5].Count() * r[6].Count() * r[7].Count() *
                    r[8].Count() * r[9].Count() * r[10].Count() * r[11].Count() *
                    r[12].Count();
                //Om insatsen är högre än 135kr, ta bort senaste inlagda tecknet
                if (sum > 135)
                {
                    r[match] = r[match].Replace(sign, "");
                }
                num++;
            }
            return stryktipsCoupon;
        }

        private StryktipsCoupon GenerateCouponMarks(StryktipsCoupon stryktipsCoupon, int price, int wholeGuards = 13, int halfGuards = 13)
        {
            bool canAddWholeGuard = true;
            bool canAddHalfGuard = true;

            //Lägg in mest spelade
            foreach (var match in stryktipsCoupon.Matches)
            {
                if (match.HomeWinBetters > match.DrawBetters && match.HomeWinBetters > match.AwayWinBetters)
                    match.One = true;
                else if (match.DrawBetters > match.AwayWinBetters)
                    match.Cross = true;
                else
                    match.Two = true;
            }

            //Lägg in minst spelade
            stryktipsCoupon.OrderByLeastPlayed();
            foreach (var match in stryktipsCoupon.Matches)
            {
                if (match.HomeWinBetters < match.DrawBetters && match.HomeWinBetters < match.AwayWinBetters)
                    match.One = true;
                else if (match.DrawBetters-10 < match.AwayWinBetters)
                    match.Cross = true;
                else
                    match.Two = true;


                if((stryktipsCoupon.HalfGuards() >= halfGuards && stryktipsCoupon.WholeGuards() >= wholeGuards) || stryktipsCoupon.CouponPrice() >= price)
                {
                    return stryktipsCoupon;
                }
            }


            //DEBUG
            foreach (var match in stryktipsCoupon.Matches)
            {
                Console.WriteLine(match.MatchNumber + ": " + match.HomeWinBetters + " " + match.DrawBetters + " " + match.AwayWinBetters);
            }

            return stryktipsCoupon;
        }

        //private CouponRow EvaluateMatch(StryktipsMatches.Match match)
        //{
        //    var couponRow = new CouponRow();
        //    if (match.HomeWin > 25)
        //    {
        //        couponRow.One = true;
        //    }
        //    if (match.Draw > 25)
        //    {
        //        couponRow.Cross = true;
        //    }
        //    if (match.AwayWin > 25)
        //    {
        //        couponRow.Two = true;
        //    }
        //    return couponRow;
        //}

        private void GetTeamStrength()
        {
            
        }
    }
}
