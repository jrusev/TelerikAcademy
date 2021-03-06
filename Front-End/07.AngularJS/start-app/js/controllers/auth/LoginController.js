'use strict';

myApp.controller('LoginController',
    function LoginController($rootScope, $scope, $location, appData, auth, notifier) {
        if (auth.isAuthenticated()) {
            $location.path('/');
            return;
        }

        $scope.username = null;

        $scope.login = function () {
            appData.login($scope.username, $scope.password)
                .then(function (data) {
                    notifier.success('Login successful!');
                    auth.login(data.userName, data.access_token);
                    $rootScope.isLoggedIn = true;
                    $rootScope.username = auth.getUsername();
                    $location.path('/');
                }, function (data) {
                    ModalDialog.show("The request is invalid.", data.error_description);
                });
        }
    }
);
