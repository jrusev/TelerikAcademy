'use strict';

ticTacToeApp.controller('ListGamesController',
    function ListGamesController($rootScope, $scope, $location, $window, $interval, ticTacToeData, auth) {
        if (!auth.isAuthenticated()) {
            $location.path('/login');
            return;
        }
        
        function startUpdating(delayMilliseconds, fn) {
            var intervalId = $interval(fn, delayMilliseconds);            
            $scope.$on('$destroy', function () {
                $interval.cancel(intervalId);
            });
        }
        
        $scope.currentPlayer = $rootScope.username;

        // g.SecondPlayerId == userId && (g.State == TurnO || g.State == TurnX)
        function getJoinedGames() {
            ticTacToeData
                .getJoinedGames(auth.access_token())
                .then(function (data) {
                    $scope.joinedGames = data;
                    $scope.allMyGames = $scope.allMyGames.concat(data);
                });
        }
        
        // g.State == WaitingForSecondPlayer && g.FirstPlayerId != userId
        function getAvailableGames() {
            ticTacToeData
                .getAvailableGames(auth.access_token())
                .then(function (data) {
                    $scope.availableGames = data;
                    $scope.allMyGames = $scope.allMyGames.concat(data);
                });
        }

        // g.FirstPlayerId == userId)
        function getMyGames() {
            ticTacToeData
            .getMyGames(auth.access_token())
            .then(function (data) {
                $scope.allMyGames = $scope.allMyGames.concat(data);
            });
        };
        
        function getMyGamesHistory() {
            ticTacToeData
            .getMyGamesHistory(auth.access_token())
            .then(function (data) {
                $scope.myGamesHistory = data;
            });
        };
        
        function updateGames() {
            $scope.allMyGames = [];
            getJoinedGames();
            getAvailableGames();
            getMyGames();        
            getMyGamesHistory();
        };
        
        updateGames();
        
//        startUpdating(5000, function() {
//            console.log(".");
//        });
        
        $scope.joinGame = function (gameId) {
            ticTacToeData
                .joinGame(gameId, auth.access_token())
                .then(function () {
                    updateGames();
                });
        };
        
        $scope.playGame = function (gameId) {
            $location.path('/game/' + gameId);
        };
        
        $scope.playMyGame = function(gameId, status, creator) {
            if (status == 0 && creator !== $scope.currentPlayer)
                $scope.joinGame(gameId);
            else if (status != 0)
                $scope.playGame(gameId);
        };
    }
);