using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkSolution
{
    public class SolutionA : ICalcFee
    {
        public int CalcFee(DateTime Timein, DateTime Timeout)
        {
            var DayOfFee = 0;
            var HourFee = 10;
            var HalfHourFee = 7;
            var DayOfMaxFee = 50;

            var DayOfMin = GetParkMin(Timein, Timeout);
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

                    if (DayOfFee > DayOfMaxFee) DayOfFee = DayOfMaxFee; //超過一天
                    break;
            }
            return DayOfFee;
        }

        public int GetParkMin(DateTime Timein, DateTime Timeout)
        {
                                  
            return new  TimeSpan().GetDayMinWithoutSec(Timein,Timeout);
        }
    }
}