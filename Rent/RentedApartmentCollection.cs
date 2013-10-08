using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rent
{
    public class RentedApartmentCollection
    {
        public IList<RentedApartment> apartments { get; set; }

        public string SiteDomain { get; set; }
    }
}
