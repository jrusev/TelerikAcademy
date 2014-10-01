'use strict';

ticTacToeApp.controller('ListUsersController',
    function ListUsersController($scope, ticTacToeData) {
        $scope.sort = 'Id';
        ticTacToeData
            .getUsers()
            .then(function (data) {
                $scope.users = data;
            });
    }
);