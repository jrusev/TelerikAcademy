'use strict';

ticTacToeApp.controller('RegistrationController',
    function RegistrationController($rootScope, $scope, $resource, $location, ticTacToeData, auth, notifier) {
        if (auth.isAuthenticated()) {
            $location.path('/');
            return;
        }

        $scope.username = null;

        $scope.registration = function () {
            ticTacToeData.register($scope.username, $scope.password)
                .then(function () {
                    notifier.success('Registration successful!');
                    ticTacToeData.login($scope.username, $scope.password)
                        .then(function (data) {
                            auth.login(data.userName, data.access_token);
                            $rootScope.isLoggedIn = true;
                            $rootScope.username = auth.getUsername();
                            $location.path('/');
                        }, function (data) {
                            ModalDialog.show("The request is invalid.", data.error_description);
                        });
                }, function (data) {
                    ModalDialog.show(data.Message, data.ModelState[Object.keys(data.ModelState)[0]][0]);
                });
        }
    }
);
