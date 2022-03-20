using EXO_02.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace EXO_02.Models
{
    public class Venue
    {
        public static string GenerateURL(double latitude, double longitude)
        {
            return string.Format(Constants.VENUE_SERCH, latitude, longitude);
        }
    }
}
