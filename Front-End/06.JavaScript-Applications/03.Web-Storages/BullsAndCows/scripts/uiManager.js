define(["jquery", "storage"], function ($, storage) {
    'use strict';

    var _countGuesses;
    var outputBox = document.getElementById('output');

    document.getElementById('submit').style.visibility = 'hidden';
    document.getElementById('scoreBoard').style.visibility = 'hidden';


    function showSubmitForm(countGuesses) {
        _countGuesses = countGuesses;
        var submitForm = document.getElementById('submit');
        submitForm.style.visibility = '';
        submitForm.focus();
        submitForm.addEventListener('change', onNameSubmit, false);
        document.getElementById('input').disabled = true;
    }

    function onNameSubmit(evt) {
        storage.addScore(this.value, _countGuesses);
        updateScoreTable();
        evt.target.style.visibility = 'hidden';
    }

    function updateScoreTable(evt) {
        document.getElementById('scoreBoard').style.visibility = '';
        var scoreList = document.getElementById('scoreList');
        scoreList.innerHTML = '';
        storage.getScores().forEach(function (entry) {
            scoreList.innerHTML += '<li>' + entry.name + ' -> ' + entry.score + '</li>'
        });
    }

    function print(text) {
        outputBox.innerHTML += '<li>' + text + '</li>'
    }

    return {
        print: print,
        showSubmitForm: showSubmitForm,
    }

});