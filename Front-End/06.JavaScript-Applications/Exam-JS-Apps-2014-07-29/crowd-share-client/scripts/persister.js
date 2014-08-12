define(["jquery", "requester"], function ($, requester) {

    //var baseURL = "http://localhost:3000/";
    var baseURL = "http://jsapps.bgcoder.com/";

    function getPosts() {
        return requester.getJSON(baseURL + 'post');
    };

    function registerUser(data) {
        return requester.postJSON(baseURL + 'user', data);
    };

    function loginUser(data) {
        return requester.postJSON(baseURL + 'auth', data)
            .then(function (data) {
                var sessionKey = data['sessionKey'];
                localStorage.setItem('sessionKey', data['sessionKey']);
                localStorage.setItem('username', data['username']);
            });
    }

    function logout() {
        var sessionKey = localStorage.getItem('sessionKey');
        var headers = {
            'X-SessionKey': sessionKey
        };
        return requester.putJSON(baseURL + 'user', undefined, headers)
            .then(function () {
                localStorage.clear();
            });
    }

    function sendPost(message, sessionKey) {
        var sessionKey = localStorage.getItem('sessionKey');
        var headers = {
            'X-SessionKey': sessionKey
        };
        return requester.postJSON(baseURL + 'post', message, headers);
    }

    function search(pattern, username) {
        // http://services-root/post?pattern=lorem%20ipsum&user=minkov
        var query = '';

        if (pattern) {
            query = '?pattern=' + pattern.toLowerCase();
            if (username)
                query += '&user=' + username.toLowerCase();
        } else {
            query = '?user=' + username.toLowerCase();
        }

        var uri = encodeURI(baseURL + 'post' + query);
        return requester.getJSON(uri);
    }

    function isLoggedIn() {
        var sessionKey = localStorage.getItem('sessionKey');
        return sessionKey ? true : false;
    }

    function getUsername() {
        return localStorage.getItem('username');
    }

    return {
        sendPost: sendPost,
        getPosts: getPosts,
        registerUser: registerUser,
        loginUser: loginUser,
        sendPost: sendPost,
        logout: logout,
        search: search,
        isLoggedIn: isLoggedIn,
        getUsername: getUsername
    }
});