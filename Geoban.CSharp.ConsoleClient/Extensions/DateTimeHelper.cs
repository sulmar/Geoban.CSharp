using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geoban.CSharp.ConsoleClient.Extensions
{
    public class DateTimeHelper
    {
        public static bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday
                 || date.DayOfWeek == DayOfWeek.Sunday;
        }
    }


    public static class DateTimeExtensions
    {
        public static bool IsWeekend(this DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday
                 || date.DayOfWeek == DayOfWeek.Sunday;
        }

        public static DateTime AddWorkingDays(this DateTime date, int days)
        {
            return date.AddDays(days);
        }

    }


  
}
