'use strict';

myApp.controller('MainController',
    function MainPageController($scope, $rootScope, auth) {
        
        if (auth.isAuthenticated()) {
            $rootScope.isLoggedIn = true;
            $rootScope.username = auth.getUsername();
        }
    }
);