using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identifiers
{
    public class Season
    {
        public static Guid PremierLeague_2014_2015 = new Guid("2BAB6261-30E5-4158-A11D-841D7D075664");
        public static Guid PremierLeague_2013_2014 = new Guid("5618CB3C-81AD-489F-BB0F-37F008A118F4");
        public static Guid PremierLeague_2012_2013 = new Guid("0F8F4386-DEA8-4BF5-9F29-9E9926091B4C");

        public static Guid Championship_2014_2015 = new Guid("C7FDD84C-5E37-4B9C-A8ED-BE80E614151C");
        public static Guid Championship_2013_2014 = new Guid("688853FA-6622-463C-8A6C-DAE686477213");
        public static Guid Championship_2012_2013 = new Guid("2E744C2B-08AE-49DE-8E41-10B4604760BE");
    }

    public class Teams
    {
        public static Guid Arsenal = new Guid();
        public static Guid Liverpool = new Guid();
        public static Guid ManUnited = new Guid();
    }
}
