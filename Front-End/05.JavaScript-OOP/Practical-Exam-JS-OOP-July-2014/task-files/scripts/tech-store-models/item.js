define(function () {
    'use strict';
    var Item;

    Item = (function () {
        var NAME_MIN, NAME_MAX, ValidTypes;

        NAME_MIN = 6;
        NAME_MAX = 40;
        ValidTypes = {
            'accessory': true,
            'smart-phone': true,
            'notebook': true,
            'pc': true,
            'tablet': true
        };

        function isNumber(n) {
            return !isNaN(parseFloat(n)) && isFinite(n);
        }

        function Item(type, name, price) {
            if (!ValidTypes[type]) {
                throw {
                    message: 'Item type is not of any of the allowed types!'
                };
            }
            this.type = type;

            if ((typeof name !== "string") || name.length < NAME_MIN || name.length > NAME_MAX) {
                throw {
                    message: 'Name must be a regular string between ' + NAME_MIN + ' and ' + NAME_MAX + ' characters!'
                };
            }
            this.name = name;

            if (!isNumber(price) || price < 0) {
                throw {
                    message: 'Price is not a number or negative price!'
                };
            }
            this.price = price;
        }

        Item.prototype.toString = function () {
            return '{' + this.type + ', ' + this.name + ', ' + this.price + '}';
        };

        return Item;
    }());

    return Item;
});