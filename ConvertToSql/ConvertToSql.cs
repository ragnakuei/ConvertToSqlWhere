using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConvertToSqlLibrary
{
    public class ConvertToSql
    {
        private Dictionary<string, string> regexPatterns = new Dictionary<string, string>{
                { @"not\((\w+):equals\(\""(.+?)\""\)\)" , "$1 <> '$2'" },
                { @"not\((\w*):equals\((\d+?)\)\)"   , "$1 <> $2"   },
                { @"(\w+):equals\((\d*?)\)"    , "$1 = $2"    },
                { @"(\w+):equals\(\""(.+?)\""\)"    , "$1 = '$2'"  },
                { @"^(and|or)\((.+?),(.+?)\)$","($2 $1 $3)" },
         };

        public string ToWhere(string input)
        {
            foreach (var regexPattern in regexPatterns)
            {
                var pattern = regexPattern.Key;
                var replace = regexPattern.Value;

                var match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    input = Regex.Replace(input, pattern, replace);
                }
            }

            return "where "+ input;
        }
    }
}
