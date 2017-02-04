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
        private List<RegexStore> regexStores = new List<RegexStore>{
              new RegexStore { Pattern = @"not\((\w+):equals\(\""(.+?)\""\)\)"  , Replace = "$1 <> '$2'" },
              new RegexStore { Pattern = @"not\((\w*):equals\((\d+?)\)\)"  , Replace = "$1 <> $2" },
              new RegexStore { Pattern = @"(\w+):equals\(\""(.+?)\""\)"  , Replace = "$1 = '$2'" },
              new RegexStore { Pattern = @"(\w+):equals\((\d*?)\)"  , Replace = "$1 = $2" },
              new RegexStore { Pattern = @"(and|or)\((?!and|or)(.*?),(.*?)\)"  , Replace = "($2 $1 $3)" },
              new RegexStore { Pattern = @"^(and|or)\((.+?),(.+?)\)$"  , Replace = "$2 $1 $3" },
         };

        public string ToWhere(string input)
        {
            for (int i = 0; i <= 3; i++)
            {
                var pattern = regexStores[i].Pattern;
                var replace = regexStores[i].Replace;

                var match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    input = Regex.Replace(input, pattern, replace);
                }
            }

            var patternAndOr = regexStores[4].Pattern;
            var replaceAndOr = regexStores[4].Replace;
            var matchAndOr = Regex.Match(input, patternAndOr);
            while (matchAndOr.Success)
            {
                input = Regex.Replace(input, patternAndOr, replaceAndOr);
                matchAndOr = Regex.Match(input, patternAndOr);
            }

            return "where " + input;
        }
    }
}
