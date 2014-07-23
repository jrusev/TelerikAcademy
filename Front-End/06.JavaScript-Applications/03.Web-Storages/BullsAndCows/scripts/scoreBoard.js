define(["storage", "uiManager"], function (storage, ui) {
    'use strict';

    var _countGuesses;

    function saveScore(countGuesses) {
        ui.print('Please enter your nickname in the input box...')
        ui.showSubmitForm(onNameSubmit);
        _countGuesses = countGuesses;
    }

    function onNameSubmit(evt) {
        storage.addScore(this.value, _countGuesses);
        ui.updateScoreTable(storage.getScores());
        ui.hideSubmitForm();
    }

    return {
        saveScore: saveScore
    }
});