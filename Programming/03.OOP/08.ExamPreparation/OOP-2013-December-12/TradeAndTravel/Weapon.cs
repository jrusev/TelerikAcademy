using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradeAndTravel
{
    class Weapon : Item
    {
        private const int MoneyValue = 10;

        public Weapon(string name, Location location = null)
            : base(name, Weapon.MoneyValue, ItemType.Weapon, location)
        {
        }
    }
}
