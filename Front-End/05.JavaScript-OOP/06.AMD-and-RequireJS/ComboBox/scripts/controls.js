define(['jquery','handlebars'], function ($) {
    'use strict';

    var controls = (function () {

        var ComboBox = (function () {

            function ComboBox(items) {
                this._items = items;
            }

            ComboBox.prototype.render = function (templateHtml) {

                var template = Handlebars.compile(templateHtml);

                var $buffer = $('<div/>'),
                    $ul = $('<ul/>'),
                    $li = $('<li/>'),
                    $listItems;

                for (var i = 0; i < this._items.length; i++) {
                    $li.attr('data-value', i);
                    $li.html(template(this._items[i]));
                    $ul.append($li.clone(true));
                }

                $ul.appendTo($buffer);
                $listItems = $ul.children();
                $listItems.hide().first().show();

                $buffer.on('click', 'li', function () {
                    var $clicked = $(this);
                    $clicked.parent().find('.selected').removeClass('selected');
                    $clicked.addClass('selected');
                    $listItems.toggle();
                    $clicked.show();
                });

                return $buffer;
            };

            return ComboBox;

        })();

        return {
            ComboBox: function (items) {
                return new ComboBox(items);
            }
        }
    }());

    return controls;

});