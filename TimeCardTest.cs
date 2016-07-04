using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet;

namespace TimeSheet
{
    [TestClass]
    class TimeCardTest
    {
        [TestMethod]
        public void TestOverTime()
        {
            //arrange
            TimeCard t = new TimeCard();
            float expected = 44; //hours

            //act
            foreach (Day d in Enum.GetValues(typeof(DayOfWeek)))
            {
                d.SetHours(Day.type.REGULAR, 8);
            }

            //assert
            Assert.AreEqual(expected, t.CalculateOverTime());

        }
    }
}
