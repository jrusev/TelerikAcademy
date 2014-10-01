'use strict';

myApp.controller('ListUsersController',
    function ListUsersController($scope, appData) {
        $scope.sort = 'Id';
        appData
            .getUsers()
            .then(function (data) {
                $scope.users = data;
            });
    }
);