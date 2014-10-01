'use strict';

myApp.directive('navigationBar', function() {
    return {
        restrict: 'A',
        templateUrl: 'views/directives/navigation-bar.html',
        replace: true,
        scope: false
    }
});