'use strict';

app.factory('UsersResource', function($resource, baseUrl) {
    var usersApi = baseUrl + '/api/users';
    var accountApi = baseUrl + '/token';

    var UsersResource = {
        register:  $resource(usersApi + '/register'),
        login:  $resource(accountApi),
        logout:  $resource(usersApi + '/logout')
    }

    return UsersResource;
});