using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkSolution
{
    public class SolutionB : ICalcFee
    {
        public int CalcFee(DateTime Timein, DateTime Timeout)
        {
            var DayOfFee = 0;
            var DayOfMin = GetParkMin(Timein, Timeout);

            if (Timein.DayOfWeek != DayOfWeek.Saturday && Timein.DayOfWeek != DayOfWeek.Sunday)//平日
            {
                switch (DayOfMin)
                {
                    case <= 10:
                        DayOfFee = 0;
                        break;

                    case <= 30:
                        DayOfFee = 7;
                        break;

                    case <= 59:
                        DayOfFee = 10;
                        break;

                    case >= 60:
                        var Hour = DayOfMin / 60;
                        DayOfFee = DayOfFee + Hour * 10;
                        var Min = DayOfMin % 60;
                        if (Min != 0)
                        {
                            if (Min > 30) DayOfFee = DayOfFee + 10;
                            else DayOfFee = DayOfFee + 7;
                        }

                        if (DayOfFee > 50) DayOfFee = 50; //超過一天
                        break;
                }
            }
            else
            {
                switch (DayOfMin)
                {
                    case <= 0:
                        DayOfFee = 0;
                        break;

                    case <= 59:
                        DayOfFee = 15;
                        break;

                    case >= 60:
                        var Hour = DayOfMin / 60;
                        DayOfFee = DayOfFee + Hour * 15;
                        var Min = DayOfMin % 60;
                        if (Min != 0)
                        {
                            DayOfFee = DayOfFee + 15;
                        }

                        if (DayOfFee > 250) DayOfFee = 250; //超過一天
                        break;
                }
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