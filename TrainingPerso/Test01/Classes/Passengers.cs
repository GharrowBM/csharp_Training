using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test01.Classes
{
    internal class BusinessClassPassenger
    {
        public override string ToString()
        {
            return $"Business Class";
        }
    }
    internal class FirstClassPassenger
    {
        public int AirMiles { get; set; }
        public override string ToString()
        {
            return $"First Class with {AirMiles:N0} air miles";
        }
    }
    internal class CoachClassPassenger
    {
        public double CarryOnKG { get; set; }
        public override string ToString()
        {
            return $"Coach Class with {CarryOnKG:N2} KG carry on";
        }
    }
}
