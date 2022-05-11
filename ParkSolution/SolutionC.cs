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
                DayOfFee = GetWeekdayFee(DayOfMin);
            }
            else
            {
                DayOfFee = GetHolidayFee(DayOfMin);
            }

            return DayOfFee;
        }

        private int GetHolidayFee(int DayOfMin)
        {
            return 0;//假日免費
        }

        private int GetWeekdayFee(int DayOfMin)
        {
            var DayOfFee = 0;
            var DayOfMaxFee = 300;
            var HourFee = 20;
            var AddFeeRate = 10;
            var HourFeeMax = 30;

            switch (DayOfMin)
            {
                case <= 0:
                    DayOfFee = 0;
                    break;

                case <= 59:
                    DayOfFee = HourFee;
                    break;

                case >= 60:

                    while (DayOfMin > 0)
                    {
                        DayOfFee = DayOfFee + HourFee;
                        DayOfMin = DayOfMin - 60;
                        if (HourFee < HourFeeMax) HourFee = HourFee + AddFeeRate;
                    }

                    if (DayOfFee > DayOfMaxFee) DayOfFee = DayOfMaxFee; //超過一天
                    break;
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