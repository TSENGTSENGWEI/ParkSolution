using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkSolution
{
    public class ParkingFee
    {
        private readonly ICalcFee _usefee;

        public ParkingFee(DateTime start, DateTime end, ICalcFee UseFee)
        {
            _usefee = UseFee;
            Items = CalFeeForMultiDay(start, end);
            TotalFee = Items.Sum(x => x.Fee);
            TotalDays = Items.Count();
        }

        public IEnumerable<SingleDayFee> Items { get; set; }
        public int TotalFee { get; set; }
        public int TotalDays { get; set; }

        public IEnumerable<SingleDayFee> CalFeeForMultiDay(DateTime start, DateTime end)
        {
            //判斷大小關係
            if (start > end) throw new ArgumentException("輸出時間大於輸入時間");
            //計算天數
            var dayList = new List<SingleDayFee>();

            while (start.Date != end.Date)
            {
                dayList.Add(new SingleDayFee()
                {
                    StartTime = start,
                    EndTime = start.Add(-start.TimeOfDay).AddDays(1).AddMinutes(-1), //23:59
                    Fee = 0
                });

                start = start.Add(-start.TimeOfDay).AddDays(1);//00:00
            }

            dayList.Add(new SingleDayFee() //00:00-Timeout
            {
                StartTime = start,
                EndTime = end,
                Fee = 0
            });

            foreach (var SingleFee in dayList)
            {
                SingleFee.Fee = _usefee.CalcFee(SingleFee.StartTime, SingleFee.EndTime);
            }

            return dayList;
        }
    }
}