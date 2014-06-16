$.fn.tabs = function () {
    $container = $(this);
    $container.addClass('tabs-container');    
    
    toggleVisibility($('.tab-item:first-of-type'));
    
    $('.tab-item').click(function() {
        toggleVisibility($(this));
    });
    
    function toggleVisibility($current) {
        $('.tab-item').removeClass('current');
        $current.addClass('current');
        $('.tab-item-content').hide();
        $('.current .tab-item-content').show();
    }
};