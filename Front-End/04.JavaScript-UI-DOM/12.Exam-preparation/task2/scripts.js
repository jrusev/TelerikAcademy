$.fn.tabs = function () {
    $tabsControl = this;
    $tabsControl.addClass('tabs-container');    
    
    setCurrent($tabsControl.find('.tab-item').first());
    
    $tabsControl.find('.tab-item').click(function() {
        setCurrent($(this));
    });
    
    function setCurrent($current) {
        $tabsControl.find('.tab-item').removeClass('current');
        $tabsControl.find('.tab-item-content').hide();        
        $current.addClass('current').find('.tab-item-content').show();
    }
};