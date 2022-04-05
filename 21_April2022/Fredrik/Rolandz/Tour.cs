using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rolandz
{
    public class Tour
    {
        public List<City> VisitedCities { get; set; } = new();
        public int TotalDistance { get; set; }

        public Tour(City firstCity)
        {
            VisitedCities.Add(firstCity);
        }

        public Tour(int totalDistance)
        {
            TotalDistance = totalDistance;
        }
    }
}
