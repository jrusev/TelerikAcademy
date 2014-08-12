define(['jquery', 'handlebars'], function ($, Handlebars) {

    Handlebars.registerHelper("prettifyDate", function (timestamp) {
        
        var date1 = new Date(timestamp).getTime();
        var date2 = Date.now();
        
        var timeDiff = Math.abs(date2 - date1);
        var diffMinutes = Math.ceil(timeDiff / (1000 * 60 )); 
        
        return diffMinutes;
    });

    $.fn.loadTemplate = function (data) {
        var $this = this;
        var templateID = $this.attr('data-template');
        var templateHtml = $("#" + templateID).html();
        template = Handlebars.compile(templateHtml);

        var compiled = template({
            items: data
        });
        $this.html(template({
            items: data
        }));

        return $this;
    }

});