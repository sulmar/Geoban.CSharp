using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geoban.CSharp.ConsoleClient.LazyCollections
{
    public class Helper
    {
        //public IEnumerable<string> GetWeekDays()
        //{
        //    var weekdays = new List<string>
        //    {
        //        "Poniedziałek",
        //        "Wtorek",
        //        "Środa",
        //        "Czwartek",
        //        "Piątek",
        //        "Sobota",
        //        "Niedziela"
        //    };

        //    return weekdays;
        //}

        public IEnumerable<string> GetWeekDays()
        {
            yield return "Poniedziałek";
            yield return "Wtorek";
            yield return "Środa";
            yield return "Czwartek";
            yield return "Piątek";
            yield return "Sobota";
            yield return "Niedziela";
        }

    }
}
