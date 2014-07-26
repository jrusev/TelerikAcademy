var JSONrequest = (function ($) {
    'use strict';

    // Create a module that exposes methods for performing HTTP requests by given URL and headers
    // getJSON and postJSON
    // Both methods should work with promises
    return {
        getJSON: function (url, callback) {
            // jQuery.get() returns a promise
            return $.get(url, callback, "json");
        },
        postJSON: function (url, data, callback) {
            // jQuery.post() returns a promise
            return $.post(url, data, callback, "json");
        }
    }
})(jQuery);