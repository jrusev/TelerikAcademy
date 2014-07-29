define(["jquery"], function ($) {

    var $wrapper = $("#mainContent");

    function load(file) {
        // jQuery.get() returns a promise, so the function returns a promise
        return $.get("views/" + file + ".html", function (data) {
            $wrapper.html(data);
        });
    }

    return {
        load: load
    }
});