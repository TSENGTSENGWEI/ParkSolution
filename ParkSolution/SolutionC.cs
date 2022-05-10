using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkSolution
{
    public class SolutionC : ICalcFee
    {
        public int CalcFee(DateTime Timein, DateTime Timeout)
        {
            var DayOfFee = 0;
            var DayOfMin = GetParkMin(Timein, Timeout);

            if (Timein.DayOfWeek != DayOfWeek.Saturday && Timein.DayOfWeek != DayOfWeek.Sunday)//平日
            {
                switch (DayOfMin)
                {
                    case <= 0:
                        DayOfFee = 0;
                        break;

                    case <= 59:
                        DayOfFee = 20;
                        break;

                    case >= 60:
                        var Rate = 20;

                        while (DayOfMin > 0)
                        {
                            DayOfFee = DayOfFee + Rate;
                            DayOfMin = DayOfMin - 60;
                            if (Rate < 30) Rate = Rate + 10;
                        }

                        if (DayOfFee > 300) DayOfFee = 300; //超過一天
                        break;
                }
            }
            else
            {
                DayOfFee = 0;
            }

            return DayOfFee;
        }

        public int GetParkMin(DateTime Timein, DateTime Timeout)
        {
            Timeout = Timeout.AddSeconds(-Timeout.Second);
            Timein = Timein.AddSeconds(-Timein.Second);
            var TimeSpan = Timeout - Timein;
            var DayofMin = TimeSpan.Minutes;

            if (TimeSpan.Hours > 0) DayofMin = DayofMin + (60 * TimeSpan.Hours);

            return DayofMin;
        }
    }
}