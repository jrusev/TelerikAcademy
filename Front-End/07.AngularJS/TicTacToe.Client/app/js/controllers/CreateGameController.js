'use strict';

ticTacToeApp.controller('CreateGameController',
    function CreateGameController($scope, $location, ticTacToeData, auth, notifier) {
        if (!auth.isAuthenticated()) {
            $location.path('/login');
            return;
        }

        $scope.createGame = function (gameName) {
            ticTacToeData.createGame(gameName, auth.access_token())                
                .then(function () {
                    notifier.success('Game created!');
                    $location.path('/');
                },
                 function (data){
                    ModalDialog.show("The request is invalid.", data.Message);
                 });
        };        
    }
);