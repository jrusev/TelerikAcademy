'use strict';

var myApp = angular.module('myApp', ['ngResource', 'ngRoute'])
    .config(function ($routeProvider) {

        $routeProvider
            .when('/', {
                templateUrl: 'views/games.html'
            })
            .when('/games/', {
                templateUrl: 'views/games.html'
            })
            .when('/users/', {
                templateUrl: 'views/users.html'
            })
            .when('/login', {
                templateUrl: 'views/auth-login.html'
            })
            .when('/registration', {
                templateUrl: 'views/auth-registration.html'
            })
            .otherwise({redirectTo: '/'});
    })
    .constant('toastr', toastr)
    .constant('baseServiceUrl', 'http://tic-tac-toe-services.apphb.com/');