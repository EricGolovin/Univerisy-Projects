using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_BusSchedule.Extensions
{
    public static class WordFormattingExtension
    {
        public static String RemoveWhitespaces(this String str)
        {
            return new string(str.ToCharArray().Where(c => !Char.IsWhiteSpace(c)).ToArray());
        }
    }
}
