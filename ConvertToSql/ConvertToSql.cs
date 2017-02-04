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
        public string ToWhere(string input)
        {
            string regexPattern = @"(.*?):equals\((\d*?)\)";
            var result = "where ";

            var match = Regex.Match(input, regexPattern);
            if (match.Success)
            {
                var regexReplace = "$1 = $2";
                result += Regex.Replace(match.Value, regexPattern, regexReplace);
            }
            return result;
        }
    }
}
