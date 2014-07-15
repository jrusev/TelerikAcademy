define(['tech-store-models/item'], function (Item) {
    'use strict';
    var Store;

    Store = (function () {
        var NAME_MIN, NAME_MAX;
        NAME_MIN = 6;
        NAME_MAX = 30;

        function compareByName(item1, item2) {
            var name1, name2;
            name1 = item1.name.toLowerCase();
            name2 = item2.name.toLowerCase();
            return (name1 > name2) ? 1 : (name1 < name2) ? -1 : 0;
        }

        // Constructor
        function Store(name) {
            if ((typeof name !== "string") || name.length < NAME_MIN || name.length > NAME_MAX) {
                throw {
                    message: 'Name must be a regular string between ' + NAME_MIN + ' and ' + NAME_MAX + ' characters!'
                };
            }
            this.name = name;
            this._items = [];
        }

        Store.prototype.addItem = function (item) {
            if (!(item instanceof Item)) {
                throw {
                    message: 'Trying to add an object that is not of type Item!'
                };
            }
            this._items.push(item);
            return this;
        };

        Store.prototype.getAll = function () {
            return this._items.sort(compareByName).slice(0);
        };

        Store.prototype.getSmartPhones = function () {
            return this._items.filter(function (item) {
                return item.type === 'smart-phone';
            }).sort(compareByName);
        };

        Store.prototype.getMobiles = function () {
            return this._items.filter(function (item) {
                return (item.type === 'smart-phone') || (item.type === 'tablet');
            }).sort(compareByName);
        };

        Store.prototype.getComputers = function () {
            return this._items.filter(function (item) {
                return (item.type === 'pc') || (item.type === 'notebook');
            }).sort(compareByName);
        };

        Store.prototype.filterItemsByPrice = function (options) {
            var min, max;
            min = !options || !options.min ? 0 : options.min;
            max = !options || !options.max ? Number.POSITIVE_INFINITY : options.max;
            return this._items.filter(function (item) {
                return min < item.price && item.price < max;
            }).sort(function (item1, item2) {
                return item1.price - item2.price;
            });
        };

        Store.prototype.filterItemsByType = function (filterType) {
            return this._items.filter(function (item) {
                return item.type === filterType;
            }).sort(compareByName);
        };

        Store.prototype.filterItemsByName = function (partOfName) {
            var searchValue = partOfName.toLowerCase();
            return this._items.filter(function (item) {
                return item.name.toLowerCase().indexOf(searchValue) > -1;
            }).sort(compareByName);
        };

        Store.prototype.countItemsByType = function () {
            var result = {};
            this._items.forEach(function (item) {
                result[item.type] = result[item.type] ? result[item.type] + 1 : 1;
            });
            return result;
        };

        return Store;
    }());

    return Store;
});