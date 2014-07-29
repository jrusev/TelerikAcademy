define(['jquery', 'handlebars'], function ($, Handlebars) {

    $.fn.loadTemplate = function (data) {
        var $this = this;
        var templateID = $this.attr('data-template');
        var templateHtml = $("#" + templateID).html();
        template = Handlebars.compile(templateHtml);

        $this.html(template({
            items: data
        }));

        return $this;
    }

});