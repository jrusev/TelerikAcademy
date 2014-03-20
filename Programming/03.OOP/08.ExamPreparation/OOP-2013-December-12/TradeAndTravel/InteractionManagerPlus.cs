namespace TradeAndTravel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class InteractionManagerPlus : InteractionManager
    {
        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;
            switch (locationTypeString)
            {
                case "mine":
                    location = new Mine(locationName);
                    break;
                case "forest":
                    location = new Forest(locationName);
                    break;
                default:
                    location = base.CreateLocation(locationTypeString, locationName);
                    break;
            }

            return location;
        }

        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new Wood(itemNameString, itemLocation);
                    break;
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
                default:
                    item = base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
                    break;
            }

            return item;
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;
            switch (personTypeString)
            {
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                    break;
                default:
                    person = base.CreatePerson(personTypeString, personNameString, personLocation);
                    break;
            }

            return person;
        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather":
                    this.HandleGatherItemFromLocation(commandWords, actor);
                    break;
                case "craft":
                    this.HandleCraftItem(commandWords, actor);
                    break;
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }
        }

        private void HandleCraftItem(string[] commandWords, Person actor)
        {
            // Syntax: kiro craft weapon craftedWeapon
            // 
            // A Person should be able to craft Weapons and Armor
            //
            // Crafting an Armor requires that the Person has Iron in his inventory
            // Results in adding an Armor item in the Person’s inventory
            //
            // Crafting a Weapon requires that the Person has Iron and Wood in his inventory
            bool hasIron = false;
            bool hasWood = false;

            var inventory = actor.ListInventory();
            foreach (var item in inventory)
            {
                if (item is Iron)
                {
                    hasIron = true;
                }
                else if (item is Wood)
                {
                    hasWood = true;
                }
            }

            if (commandWords[2] == "weapon")
            {
                if (hasIron && hasWood)
                {
                    this.AddToPerson(actor, new Weapon(commandWords[3]));
                    return;
                }
            }

            if (commandWords[2] == "armor")
            {
                if (hasIron)
                {
                    this.AddToPerson(actor, new Armor(commandWords[3]));
                    return;
                }
            }
        }

        private void HandleGatherItemFromLocation(string[] commandWords, Person actor)
        {
            // Syntax: Joro gather newItemName 
            //
            // A Person should be able to gather from mines and from forests
            //
            // A Person can gather from a forest only if he has a Weapon in his inventory
            // Gathering from a forests results in adding a Wood item in the Person’s inventory
            //
            // A Person can gather from a mine only if he has an Armor in his inventory
            // Gathering from a mine results in adding an Iron item in the Person’s inventory
            if (actor.Location.LocationType == LocationType.Forest)
            {
                var inventory = actor.ListInventory();
                foreach (var item in inventory)
                {
                    if (item is Weapon)
                    {
                        this.AddToPerson(actor, new Wood(commandWords[2]));
                        return;
                    }
                }
            }
            else if (actor.Location.LocationType == LocationType.Mine)
            {
                var inventory = actor.ListInventory();
                foreach (var item in inventory)
                {
                    if (item is Armor)
                    {
                        this.AddToPerson(actor, new Iron(commandWords[2]));
                        return;
                    }
                }
            }
        }
    }
}