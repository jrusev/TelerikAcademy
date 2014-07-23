define(["storage", "uiManager"], function (storage, ui) {
    'use strict';

    var _countGuesses;

    function saveScore(countGuesses) {
        ui.print('Please enter your nickname in the input box...')
        ui.showSubmitForm(onNameSubmit);
        _countGuesses = countGuesses;
    }

    function onNameSubmit(evt) {
        ui.hideSubmitForm();
        var score = {
            name: evt.target.value,
            score: _countGuesses
        };

        var scoreList = storage.getScores();
        scoreList.push(score);
        storage.saveScores(_.sortBy(scoreList, 'score'));

        ui.updateScoreTable(storage.getScores());
    }

    return {
        saveScore: saveScore
    }
});