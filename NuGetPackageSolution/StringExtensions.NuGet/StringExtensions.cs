using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExtensions.NuGet
{
    public static class StringExtensions
    {
        public static string PrintMeToConsole(this string text)
        {
            Console.WriteLine(text);
            return text;
        }
    }
}
