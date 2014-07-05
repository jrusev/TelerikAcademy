define(['jquery', 'handlebars'], function ($) {
    'use strict';

    var ComboBox = (function () {

        function ComboBox(items) {
            this._items = items;
        }

        ComboBox.prototype.render = function (templateHtml) {
            
            var template, $buffer, $ul, $li;

            template = Handlebars.compile(templateHtml);

            $buffer = $('<div/>').addClass('comboBox');
            $ul = $('<ul/>');
            $li = $('<li/>');

            for (var i = 0; i < this._items.length; i++) {
                $li.html(template(this._items[i]));
                $ul.append($li.clone(true));
            }

            $ul.appendTo($buffer);
            $ul.children().hide().first().show();

            $buffer.on('click', 'li', function () {
                var $clicked = $(this);
                $clicked.parent().find('.selected').removeClass('selected');
                $clicked.addClass('selected');
                $clicked.siblings().toggle();
                $clicked.show();
            });

            // return the DOM element from the jQuery object
            return $buffer[0];
        };

        return ComboBox;

    })();

    return ComboBox;
});