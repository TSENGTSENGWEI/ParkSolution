using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkSolution
{
    public static class Expansion
    {
        public static int GetDayMinWithoutSec(this TimeSpan Span,DateTime Timein,DateTime Timeout)
        {
            Timeout = Timeout.AddSeconds(-Timeout.Second).AddMilliseconds(-Timeout.Millisecond);
            Timein = Timein.AddSeconds(-Timein.Second).AddMilliseconds(-Timein.Millisecond);

            
            Span = Timeout - Timein;
            var DayofMin = Span.Minutes;
            

            if (Span.Hours > 0) DayofMin = DayofMin + (60 * Span.Hours);

            return DayofMin;
        }
    }
}
