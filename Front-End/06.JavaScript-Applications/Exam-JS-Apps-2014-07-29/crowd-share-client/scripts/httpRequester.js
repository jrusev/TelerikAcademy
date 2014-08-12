define(['jquery', 'Q'], function ($, Q) {

    function _makeHttpRequest(url, type, data, headers) {
        var ajaxDeferred = Q.defer();
        $.ajax({
            url: url,
            type: type,
            headers: headers,
            data: data ? JSON.stringify(data) : "",
            contentType: "application/json",
            timeout: 5000,
            success: function (data) {
                ajaxDeferred.resolve(data);
            },
            error: function (error) {
                ajaxDeferred.reject(error);
            }
        });

        return ajaxDeferred.promise;
    };

    function getJSON(url) {
        return _makeHttpRequest(url, "GET");
    };

    function postJSON(url, data, headers) {
        return _makeHttpRequest(url, "POST", data, headers);
    };

    function putJSON(url, data, headers) {
        return _makeHttpRequest(url, "PUT", data, headers);
    }

    return {
        getJSON: getJSON,
        postJSON: postJSON,
        putJSON: putJSON
    }
});