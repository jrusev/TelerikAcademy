using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradeAndTravel
{
    public class Wood : Item
    {
        private const int MoneyValue = 2;

        public Wood(string name, Location location = null)
            : base(name, Wood.MoneyValue, ItemType.Wood, location)
        {
        }
    }
}
