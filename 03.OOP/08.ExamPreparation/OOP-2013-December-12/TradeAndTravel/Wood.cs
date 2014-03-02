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

        // The Wood item decreases its value each time it is dropped by 1, until it reaches 0
        public override void UpdateWithInteraction(string interaction)
        {
            if (interaction == "drop")
            {
                if (this.Value > 0)
                {
                    this.Value--;
                }                
            }
        }
    }
}