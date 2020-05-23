using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarManagement.Locations
{
    public class LocationList
    {
        public IEnumerable<Location> Locations { get; set; }
        //public LocationsFilter Filters { get; set; }
    }
}