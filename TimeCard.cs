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
        float[] RegHours = new float[DayNum * WeekNum];
        float[] SickHours = new float[DayNum * WeekNum];
        float[] VacHours = new float[DayNum * WeekNum];
        float[] TotalRegHours = new float[WeekNum];
        float[] TotalSickHours = new float[WeekNum];
        float[] TotalVacHours = new float[WeekNum];
        float[] OverTimeHours = new float[WeekNum];

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
            FillHours();
        }
        public void FillHours()
        {
            int i = 0;
            for (int WeekInstance = 0; WeekInstance <= WeekNum; WeekInstance++)
            {
                for (int DayInstance = 0; DayInstance <= DayNum; DayInstance++)
                {
                    RegHours[i] = WeekAndDay[WeekInstance, DayInstance].RegHours;
                    SickHours[i] = WeekAndDay[WeekInstance, DayInstance].SickHours;
                    VacHours[i] = WeekAndDay[WeekInstance, DayInstance].VacHours;
                    i++;
                }
            }
            FillTotalHours();
        }
        public void FillTotalHours()
        {
            float AllRegHours = 0;
            float AllSickHours = 0;
            float AllVacHours = 0;
            int WeekIncrement = 0;
            for (int WeekInstance = 0; WeekInstance <= WeekNum; WeekInstance++)
            {
                for (int DayInstance = 0; DayInstance <= DayNum; DayInstance++)
                {
                    AllRegHours += RegHours[DayInstance + WeekIncrement];
                    AllSickHours += SickHours[DayInstance + WeekIncrement];
                    AllVacHours += VacHours[DayInstance + WeekIncrement];
                }
                TotalRegHours[WeekInstance] = AllRegHours;
                TotalSickHours[WeekInstance] = AllSickHours;
                TotalVacHours[WeekInstance] = AllVacHours;
                WeekIncrement += 7;
            }
            CalculateOverTime();
        }
        public void CalculateOverTime()
        {
            int WeekInstance = 0;
            if (TotalRegHours[WeekInstance] > 40)
            {
                OverTimeHours[WeekInstance] = TotalRegHours[WeekInstance] - 40;
            }
            WeekInstance++;
        }
        public void EditDayHours(int Week, int Day, Day.type TypeChoice, float Hours)
        {
            String Type = TypeChoice.ToString();
            if(Type == "REGULAR")
            {
                WeekAndDay[Week, Day].RegHours = 0;
            }
            else if(Type == "SICK")
            {
                WeekAndDay[Week, Day].SickHours = 0;
            }
            else if(Type == "VACATION")
            {
                WeekAndDay[Week, Day].VacHours = 0;
            }
            WeekAndDay[Week, Day].SetHours(TypeChoice, Hours);
            FillHours();
        }
        public void DeleteDayHour(int Week, int Day, Day.type TypeChoice)
        {
            String Type = TypeChoice.ToString();
            if (Type == "REGULAR")
            {
                WeekAndDay[Week, Day].RegHours = 0;
            }
            else if (Type == "SICK")
            {
                WeekAndDay[Week, Day].SickHours = 0;
            }
            else if (Type == "VACATION")
            {
                WeekAndDay[Week, Day].VacHours = 0;
            }
            FillHours();
        }
    }
}
