using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rent
{
    public interface IRentParser
    {
        List<RentedApartment> Parse(string siteDomain, string html);
    }
}
