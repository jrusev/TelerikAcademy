define(['tech-store-models/item'], function (Item) {
    'use strict';
	
    var Store = (function () {
        
        function compareByName(item1, item2) {
            var name1 = item1.name.toLowerCase(),
                name2 = item2.name.toLowerCase();
            return (name1 > name2) ? 1 : (name1 < name2) ? -1 : 0;
        }

        function filterByType(types) {
            return this._items.filter(function (item) {
                for (var i = 0; i < types.length; i++)
                    if (item.type === types[i])
                        return true;
                return false;
            });
        }

        function Store(name) {
            if ((typeof name !== "string") || name.length < 6 || name.length > 30)
                throw new Error("Name must be a regular string between 6 and 30 characters!");
            this.name = name;
            this._items = [];
        }

        Store.prototype = {
            addItem: function (item) {
                if (!(item instanceof Item))
				    throw new Error("Trying to add an object that is not of type Item!");
                this._items.push(item);
                return this;
            },
            getAll: function () {
                return this._items.sort(compareByName).slice(0);
            },
            getSmartPhones: function () {
                return filterByType.call(this, ['smart-phone']).sort(compareByName);
            },
            getMobiles: function () {
                return filterByType.call(this, ['smart-phone', 'tablet']).sort(compareByName);
            },
            getComputers: function () {
                return filterByType.call(this, ['pc', 'notebook']).sort(compareByName);
            },
            filterItemsByType: function (filterType) {
                return filterByType.call(this, [filterType]).sort(compareByName);
            },
            filterItemsByPrice: function (options) {
                var min = !options || !options.min ? 0 : options.min,
                    max = !options || !options.max ? Number.MAX_VALUE : options.max;
                return this._items.filter(function (item) {
                    return min < item.price && item.price < max;
                }).sort(function (item1, item2) {
                    return item1.price - item2.price;
                });
            },
            filterItemsByName: function (partOfName) {
                var searchValue = partOfName.toLowerCase();
                return this._items.filter(function (item) {
                    return item.name.toLowerCase().indexOf(searchValue) > -1;
                }).sort(compareByName);
            },
            countItemsByType: function () {
                var result = {};
                this._items.forEach(function (item) {
                    result[item.type] = result[item.type] ? result[item.type] + 1 : 1;
                });
                return result;
            },
        };
        return Store;
    }());
    return Store;
});