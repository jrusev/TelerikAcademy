define(['comboBox'], function (ComboBox) {
    'use strict';

    return {
        ComboBox: function (items) {
            return new ComboBox(items);
        }
    }
    
});