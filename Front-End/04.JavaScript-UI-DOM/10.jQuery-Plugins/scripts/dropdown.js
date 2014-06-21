(function ($) {
    $.fn.dropdown = function () {
        var selectTag = $(this),
            $container = $('<div/>'),
            $ul = $('<ul/>'),
            $li = $('<li/>'),
            $selectOptionTags,
            $allLiElements;

        selectTag.hide();

        $container.addClass('dropdown-list-container');

        $ul.addClass('dropdown-list-options');

        $li.addClass('dropdown-list-option');

        $selectOptionTags = selectTag.find('option');

        for (var i = 0; i < $selectOptionTags.length; i++) {
            var liText = $selectOptionTags[i].text;
            $li.attr('data-value', i);
            $li.text(liText);

            $ul.append($li.clone(true));
        }

        $ul.appendTo($container);
        selectTag.after($container);

        $allLiElements = $ul.find('.dropdown-list-option');

        $allLiElements.hide().first().show();

        $container.on('click', 'li', function () {
            var $clickedLi = $(this);
            $clickedLi.parent().find('.selected').removeClass('selected');
            $clickedLi.addClass('selected');
            $allLiElements.toggle();
            $clickedLi.show();
            var optionIndex = parseInt($clickedLi.attr('data-value'));
            $selectOptionTags.removeAttr('selected');
            $($selectOptionTags[optionIndex]).attr('selected', 'selected');
        })

    }
}($));