using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee e = new Employee();
            DateTime d = new DateTime(2016, 3, 12);
            d = new DateTime(2016, 3, 13);
            int[] a = new int[] { 1, 4, 6 };
            Console.WriteLine(a[7]);
        }
    }
}
