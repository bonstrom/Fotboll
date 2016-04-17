using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identifiers
{
    public static class SeasonMatches
    {
        public static KeyValuePair<Guid, string> PremierLeague_2014_2015 = new KeyValuePair<Guid, string>(new Guid("2BAB6261-30E5-4158-A11D-841D7D075664"), "[dbo].[premierLeague1415]");
        public static KeyValuePair<Guid, string> PremierLeague_2013_2014 = new KeyValuePair<Guid, string>(new Guid("5618CB3C-81AD-489F-BB0F-37F008A118F4"), "");
        public static KeyValuePair<Guid, string> PremierLeague_2012_2013 = new KeyValuePair<Guid, string>(new Guid("0F8F4386-DEA8-4BF5-9F29-9E9926091B4C"), "");

        public static KeyValuePair<Guid, string> Championship_2014_2015 = new KeyValuePair<Guid, string>(new Guid("C7FDD84C-5E37-4B9C-A8ED-BE80E614151C"), "[dbo].[championship1415]");
        public static KeyValuePair<Guid, string> Championship_2013_2014 = new KeyValuePair<Guid, string>(new Guid("688853FA-6622-463C-8A6C-DAE686477213"), "");
        public static KeyValuePair<Guid, string> Championship_2012_2013 = new KeyValuePair<Guid, string>(new Guid("2E744C2B-08AE-49DE-8E41-10B4604760BE"), "");
    }

    public static class LeaguesTables
    {
        public static KeyValuePair<Guid, string> PremierLeague_2014_2015 = new KeyValuePair<Guid, string>(new Guid("2BAB6261-30E5-4158-A11D-841D7D075664"), "[dbo].[PremierLeagueTable1415]");
        public static KeyValuePair<Guid, string> PremierLeague_2013_2014 = new KeyValuePair<Guid, string>(new Guid("5618CB3C-81AD-489F-BB0F-37F008A118F4"), "");
        public static KeyValuePair<Guid, string> PremierLeague_2012_2013 = new KeyValuePair<Guid, string>(new Guid("0F8F4386-DEA8-4BF5-9F29-9E9926091B4C"), "");

        public static KeyValuePair<Guid, string> Championship_2014_2015 = new KeyValuePair<Guid, string>(new Guid("C7FDD84C-5E37-4B9C-A8ED-BE80E614151C"), "[dbo].[ChampionshipTable1415]");
        public static KeyValuePair<Guid, string> Championship_2013_2014 = new KeyValuePair<Guid, string>(new Guid("688853FA-6622-463C-8A6C-DAE686477213"), "");
        public static KeyValuePair<Guid, string> Championship_2012_2013 = new KeyValuePair<Guid, string>(new Guid("2E744C2B-08AE-49DE-8E41-10B4604760BE"), "");
    }


    public static class Teams
    {
        public static Guid Arsenal = new Guid();
        public static Guid Liverpool = new Guid();
        public static Guid ManUnited = new Guid();
    }
}
