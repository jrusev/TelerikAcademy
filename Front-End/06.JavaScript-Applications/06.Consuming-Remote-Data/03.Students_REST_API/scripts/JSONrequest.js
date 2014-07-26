define(['jquery'], function ($) {
    'use strict';

    // Create a module that exposes methods for performing HTTP requests by given URL and headers
    // getJSON and postJSON
    // Both methods should work with promises
    return {
        getJSON: function (url, callback, headers) {
            // jQuery.ajax() returns a promise
            return $.ajax({
                url: url,
                headers: headers,
                dataType: "json",
                data: undefined,
                success: callback
            });
        },
        postJSON: function (url, data, callback, headers) {
            // jQuery.ajax() returns a promise
            return $.ajax({
                url: url,
                type: "post",
                headers: headers,
                dataType: "json",
                data: data,
                success: callback
            });
        }
    }
});