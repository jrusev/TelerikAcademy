define(['jquery', 'handlebars'], function ($) {
    'use strict';

    function ComboBox(items) {
        this._items = items;
    }

    ComboBox.prototype.render = function (templateHtml) {

        var template = Handlebars.compile(templateHtml);
        var $buffer = $('<div/>').addClass('comboBox');
        
        this._items.forEach(function(item) {
            $(template(item)).addClass('box-item').appendTo($buffer);
        });

        $buffer.on('click', '.box-item', function () {   
            $(this).addClass('selected').show().siblings().removeClass('selected').slideToggle('fast');
        });

        return $buffer[0];
    };

    return ComboBox;
});