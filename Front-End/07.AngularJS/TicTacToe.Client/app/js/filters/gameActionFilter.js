'use strict';

ticTacToeApp.filter('gameActionFilter', function () {
    return function (state, status) {
        switch (status.state) {
        case 0: // WaitingForSecondPlayer
                
            if (status.firstPlayerName === status.currentPlayerName)
                return "";
            else
                return "Join";
                
        case 1: // TurnX (first player)
            if (status.firstPlayerName === status.currentPlayerName)
                return "Play";
            else
                return "Play";
        case 2: // TurnO (second player)
            if (status.firstPlayerName === status.currentPlayerName)
                return "Play";
            else
                return "Play";
        case 3: // WonByX (first player)
            if (status.firstPlayerName === status.currentPlayerName)
                return "Win"
            else
                return "Loss";
        case 4: // WonByO (second player)
            if (status.firstPlayerName === status.currentPlayerName)
                return "Loss"
            else
                return "Win";
        case 5: // Draw
            return "Draw"
        }
    }
});