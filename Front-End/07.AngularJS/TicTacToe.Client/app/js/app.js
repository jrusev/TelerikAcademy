'use strict';

var ticTacToeApp = angular.module('myApp', ['ngResource', 'ngRoute'])
    .config(function ($routeProvider) {
        MobileDeviceChecker.hideFooterIfOnMobileDevice();

        $routeProvider
            .when('/', {
                templateUrl: 'templates/games.html'
            })
            .when('/games/', {
                templateUrl: 'templates/games.html'
            })
            .when('/game/create', {
                templateUrl: 'templates/create-game.html'
            })
            .when('/game/:id', {
                templateUrl: 'templates/game-status.html'
            })
            .when('/scores/', {
                templateUrl: 'templates/scores.html'
            })
            .when('/users/', {
                templateUrl: 'templates/users.html'
            })
            .when('/login', {
                templateUrl: 'templates/auth-login.html'
            })
            .when('/registration', {
                templateUrl: 'templates/auth-registration.html'
            })
            .otherwise({redirectTo: '/'});
    })
    .value('toastr', toastr)
    .constant('baseServiceUrl', 'http://tic-tac-toe-webapp.apphb.com');