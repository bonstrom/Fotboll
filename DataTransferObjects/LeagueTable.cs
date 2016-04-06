using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public class LeagueTable
    {
        public LeagueTable(Team[] teams)
        {
            Teams = teams;
        }
        Team[] Teams;

    }
}
