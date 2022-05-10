using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkSolution
{
    public interface ICalcFee
    {
        int CalcFee(DateTime Timein, DateTime Timeout);

        int GetParkMin(DateTime Timein, DateTime Timeout);
    }
}