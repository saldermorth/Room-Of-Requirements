using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rolandz
{
    public class City
    {
        public string Name { get; } = string.Empty;

        public City(string name)
        {
            Name = name;
        }

        public override string ToString() => Name;
    }
}
