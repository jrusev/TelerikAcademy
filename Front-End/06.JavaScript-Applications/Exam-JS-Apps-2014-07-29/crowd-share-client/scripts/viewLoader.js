define(["jquery"], function ($) {

    var $wrapper = $("#mainContent");

    function loadFromFile(file, id) {
        var $container = $wrapper;
        if (id)
            $container = $(id);
        // jQuery.get() returns a promise, so the function returns a promise
        return $.get("views/" + file + ".html", function (data) {
            $container.html(data);
        });
    }

    function loadFromString(view) {
        // jQuery.when() returns a promise, so the function returns a promise
        return $.when($wrapper.html(partials[view]));

    }

    var partials = {
        sendMessage: '',
        viewMessages: ''
    };

    return {
        load: loadFromFile
    }
});