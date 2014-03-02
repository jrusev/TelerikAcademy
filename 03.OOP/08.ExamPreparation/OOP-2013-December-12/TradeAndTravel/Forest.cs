using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradeAndTravel
{
    class Forest : Location
    {
        public Forest(string name)
            : base(name, LocationType.Forest)
        {
        }
    }
}