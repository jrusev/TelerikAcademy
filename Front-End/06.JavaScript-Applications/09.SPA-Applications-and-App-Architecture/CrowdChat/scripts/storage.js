define([], function () {
    function getUsername() {
        return sessionStorage.getItem('username');
    };

    function setUsername(username) {
        sessionStorage.setItem('username', username);
    };

    function clearUsername() {
        sessionStorage.clear();
    };

    return {
        getUsername: getUsername,
        setUsername: setUsername,
        clearUsername: clearUsername
    }
});