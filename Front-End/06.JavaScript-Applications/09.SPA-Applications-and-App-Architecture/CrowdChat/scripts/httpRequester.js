define(['jquery'], function ($) {

    function _makeHttpRequest(url, type, data) {
        return $.ajax({
            url: url,
            type: type,
            data: data ? JSON.stringify(data) : "",
            contentType: "application/json",
            timeout: 5000
        });
    };

    function getJSON(url) {
        return _makeHttpRequest(url, "GET");
    };

    function postJSON(url, data) {
        return _makeHttpRequest(url, "POST", data);
    };

    return {
        getJSON: getJSON,
        postJSON: postJSON
    }
});