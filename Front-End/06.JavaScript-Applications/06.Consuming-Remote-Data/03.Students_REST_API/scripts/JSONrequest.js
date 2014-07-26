define(['jquery'], function ($) {
    'use strict';

    return {
        getJSON: function (url, callback, headers) {
            return $.ajax({
                url: url,
                headers: headers,
                dataType: "json",
                data: undefined,
                success: callback
            });
        },
        postJSON: function (url, data, callback, headers) {
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