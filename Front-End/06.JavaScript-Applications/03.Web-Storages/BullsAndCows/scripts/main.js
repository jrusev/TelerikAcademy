(function () {
    'use strict';

    /**
     * Create a simple number guessing game (bulls and cows).
     * Implement a high-score list and save it in localStorage.
     */

    require.config({
        paths: {
            jquery: "libs/jquery-2.1.1.min",
            underscore: "libs/underscore",
            uiManager: "uiManager",
            game: "game",
            storage: "storage",
            scoreBoard: "scoreBoard"
        }
    });

    require(["jquery", "game", "uiManager"], function ($, game, ui) {

        $(document).ready(function () {
            ui.enableInput(game.onGuess);
        });
    });

}());