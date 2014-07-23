var uiManager = (function () {
    'use strict';

    Storage.prototype.setObject =
        function setObject(key, obj) {
            this.setItem(key, JSON.stringify(obj));
    };
    Storage.prototype.getObject =
        function getObject(key) {
            return JSON.parse(this.getItem(key));
    };

    var _countGuesses;
    var outputBox = document.getElementById('output');

    var scoreBoard = localStorage.getObject('bullsCowsScoreBoard') || [];

    document.getElementById('submit').style.visibility = 'hidden';
    document.getElementById('scoreBoard').style.visibility = 'hidden';


    function attachInputHandler(handler) {
        document.getElementById('input').addEventListener('change', handler, false);
    }

    function showSubmitForm(countGuesses) {
        _countGuesses = countGuesses;
        var submitForm = document.getElementById('submit');
        submitForm.style.visibility = '';
        submitForm.focus();
        submitForm.addEventListener('change', onNameSubmit, false);
        document.getElementById('input').disabled = true;
    }

    function onNameSubmit(evt) {
        scoreBoard.push({
            name: this.value,
            score: _countGuesses
        });
        scoreBoard = _.sortBy(scoreBoard, 'score');
        localStorage.setObject('bullsCowsScoreBoard', scoreBoard)
        updateScoreTable();
        evt.target.style.visibility = 'hidden';
    }

    function updateScoreTable(evt) {
        document.getElementById('scoreBoard').style.visibility = '';
        var scoreList = document.getElementById('scoreList');
        scoreList.innerHTML = '';
        scoreBoard = localStorage.getObject('bullsCowsScoreBoard') || [];
        scoreBoard.forEach(function (entry) {
            scoreList.innerHTML += '<li>' + entry.name + ' -> ' + entry.score + '</li>'
        });
    }

    function print(text) {
        outputBox.innerHTML += '<li>' + text + '</li>'
    }

    return {
        print: print,
        showSubmitForm: showSubmitForm,
        attachInputHandler: attachInputHandler
    }

}());