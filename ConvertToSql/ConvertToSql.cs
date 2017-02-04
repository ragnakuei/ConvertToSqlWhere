﻿using System;
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
            Dictionary<string,string> regexPatterns = new Dictionary<string, string>{
                { @"(.*?):equals\((\d*?)\)"          , "$1 = $2"   },
                { @"(.*?):equals\(\""(\d*?)\""\)"    , "$1 = '$2'" }};
            var result = "where ";

            foreach (var regexPattern in regexPatterns)
            {
                var pattern = regexPattern.Key;
                var replace = regexPattern.Value;

                var match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    result += Regex.Replace(match.Value, pattern, replace);
                }
            }

            return result;
        }
    }
}
