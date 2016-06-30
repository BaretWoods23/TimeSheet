using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet
    //TODO: handle editing errors
{
    public class Day
    {
        public float TotalHours = 0;
        public float RegHours = 0;
        public float SickHours = 0;
        public float VacHours = 0;
        public  enum type { SICK, VACATION, REGULAR }
        public DateTime Date{ get; set; }
        public float HoursWorked { get; set; }
        public string HoursType { get; set; }
        public float hours = 8;
        public type value = type.REGULAR;
        private DateTime dateTime;

        public Day(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }

        public type TypeTest()
        {
            return value;
        }
        public float HoursTest()
        {
            return hours;
        }

        public void Add(type TypeChoice, float hours)
        {
            if (hours > 0)
            {
                TotalHours += hours;
                if (TypeChoice == type.REGULAR)
                {
                    RegHours += hours;
                }
                else if (TypeChoice == type.SICK)
                {
                    SickHours += hours;
                }
                else if (TypeChoice == type.VACATION)
                {
                    VacHours += hours;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Hours", "Hours must be above 0.");
            }
        }
        public bool Validate()
        {
            if (TotalHours <= 24 && TotalHours > 0)
            {
                return true;
            }else
            {
                return false;
            }
        }
    }
}
