using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rolandz
{
    public struct Trip
    {
        public City[] Cities { get; }
        public int Distance { get; }

        public Trip(City cityOne, City cityTwo, int distance)
        {
            Cities = new City[2];
            Cities[0] = cityOne;
            Cities[1] = cityTwo;
            Distance = distance;
        }
    }
}
