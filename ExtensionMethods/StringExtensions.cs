using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    public static class StringExtensions
    {
        public static string FirstChar(this string str)
        {
            return str.Substring(0,1);
        }
    }
}
