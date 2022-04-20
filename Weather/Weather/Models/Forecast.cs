using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Weather.Models
{
    public class Forecast
    {
        public string City { get; set; }
        public List<ForecastItem> Items { get; set; }

        public static implicit operator Task<object>(Forecast v)
        {
            throw new NotImplementedException();
        }
    }

    public class GroupedForecast
    {
        public string City { get; set; }
        public IEnumerable<IGrouping<DateTime, ForecastItem>> Items { get; set; }
    }
}
