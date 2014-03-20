namespace TradeAndTravel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Iron : Item
    {
        private const int MoneyValue = 3;

        public Iron(string name, Location location = null)
            : base(name, Iron.MoneyValue, ItemType.Iron, location)
        {
        }
    }
}