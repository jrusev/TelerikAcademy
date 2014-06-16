$.fn.tabs = function () {
    $tabsControl = this;
    $tabsControl.addClass('tabs-container');
    setCurrent($tabsControl.find('.tab-item').first());

    $tabsControl.find('.tab-item-title').click(function () {
        setCurrent($(this).closest('.tab-item'));
    });

    function setCurrent($tabItem) {
        $tabsControl.find('.tab-item').removeClass('current');
        $tabsControl.find('.tab-item-content').hide();
        $tabItem.addClass('current').find('.tab-item-content').show();
    }
};