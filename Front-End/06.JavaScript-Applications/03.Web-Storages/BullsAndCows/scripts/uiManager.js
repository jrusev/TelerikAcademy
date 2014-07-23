define(["jquery", "storage"], function ($, storage) {
    'use strict';

    var outputBox = document.getElementById('output');

    document.getElementById('submit').style.visibility = 'hidden';
    document.getElementById('scoreBoard').style.visibility = 'hidden';

    function showSubmitForm(handler) {
        var submitForm = document.getElementById('submit');
        submitForm.style.visibility = '';
        submitForm.focus();
        submitForm.addEventListener('change', handler, false);
    }

    function disableInput() {
        document.getElementById('input').disabled = true;
    }

    function hideSubmitForm() {
        document.getElementById('submit').style.visibility = 'hidden';
    }

    function updateScoreTable(scores) {
        document.getElementById('scoreBoard').style.visibility = '';
        var scoreList = document.getElementById('scoreList');
        scoreList.innerHTML = '';
        scores.forEach(function (entry) {
            scoreList.innerHTML += '<li>' + entry.name + ' -> ' + entry.score + '</li>'
        });
    }

    function print(text) {
        outputBox.innerHTML += '<li>' + text + '</li>'
    }

    return {
        print: print,
        showSubmitForm: showSubmitForm,
        hideSubmitForm: hideSubmitForm,
        updateScoreTable: updateScoreTable,
        disableInput: disableInput
    }

});