using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet
{
    public class TimeCard
    {
        public static int WeekNum = 2;
        public static int DayNum = 7;
        public DateTime StartingDate = new DateTime(2016, 6, 26);
        Day[,] WeekAndDay = new Day[WeekNum, DayNum];
        public void FillDays()
        {
            for(int WeekInstance = 0; WeekInstance <= WeekNum; WeekInstance++)
            {
                for(int DayInstance = 0; DayInstance <= DayNum; DayInstance++)
                {
                    WeekAndDay[WeekInstance, DayInstance] = new Day(StartingDate);
                    StartingDate.AddDays(1);
                }
            }
        }
        internal object CalculateOverTime()
        {
            throw new NotImplementedException();
        }
    }
}
