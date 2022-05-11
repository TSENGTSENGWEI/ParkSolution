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
            var DayOfFee = 0;
            var HolidayOfMaxFee = 250;
            var HolidayHoureFee = 15;

            switch (DayOfMin)
            {
                case <= 0:
                    DayOfFee = 0;
                    break;

                case <= 59:
                    DayOfFee = HolidayHoureFee;
                    break;

                case >= 60:
                    var Hour = DayOfMin / 60;
                    DayOfFee = DayOfFee + Hour * HolidayHoureFee;
                    var Min = DayOfMin % 60;
                    if (Min != 0)
                    {
                        DayOfFee = DayOfFee + HolidayHoureFee;
                    }

                    if (DayOfFee > HolidayOfMaxFee) DayOfFee = HolidayOfMaxFee; //超過一天
                    break;
            }
            return DayOfFee;
        }

        private int GetWeekdayFee(int DayOfMin)
        {
            var DayOfFee = 0;
            var WeekDayOfMaxFee = 50;
            var HourFee = 10;
            var HalfHourFee = 7;

            switch (DayOfMin)
            {
                case <= 10:
                    DayOfFee = 0;
                    break;

                case <= 30:
                    DayOfFee = HalfHourFee;
                    break;

                case <= 59:
                    DayOfFee = HourFee;
                    break;

                case >= 60:
                    var Hour = DayOfMin / 60;
                    DayOfFee = DayOfFee + Hour * HourFee;
                    var Min = DayOfMin % 60;
                    if (Min != 0)
                    {
                        if (Min > 30) DayOfFee = DayOfFee + HourFee;
                        else DayOfFee = DayOfFee + HalfHourFee;
                    }

                    if (DayOfFee > WeekDayOfMaxFee) DayOfFee = WeekDayOfMaxFee; //超過一天
                    break;
            }
            return DayOfFee;
        }

        public int GetParkMin(DateTime Timein, DateTime Timeout)
        {
            return new TimeSpan().GetDayMinWithoutSec(Timein, Timeout);
        }
    }
}