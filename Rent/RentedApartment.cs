using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rent
{
    public class RentedApartment
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string AdOwnerLoginName { get; set; }

        public ulong AdOwnerId { get; set; }

        public string AdOwnerUserUrl { get; set; }

        public DateTime AdCreated { get; set; }

        public ulong AdId { get; set; }

        public string AdUrl { get; set; }

        public bool IsFiltered { get; set; }
    }
}
