'use strict';

ticTacToeApp.controller('MainPageController',
    function MainPageController($scope, $rootScope, auth) {
        
        if (auth.isAuthenticated()) {
            $rootScope.isLoggedIn = true;
            $rootScope.username = auth.getUsername();
        }
    }
);