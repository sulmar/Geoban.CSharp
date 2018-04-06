using System;

namespace Geoban.CC.Models.SearchCriteria
{
    public abstract class PeriodSearchCriteria
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
