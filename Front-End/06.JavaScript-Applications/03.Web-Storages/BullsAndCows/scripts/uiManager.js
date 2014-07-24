define(["jquery"], function ($) {
    'use strict';

    var $container = $('#container'),
        $outputBox = $container.find('#output'),
        $inputBox = $container.find('#input-guess'),
        $scoreBoard = $container.find('#scoreBoard'),
        $submitForm = $container.find('#form-submit-name');

    hideSubmitForm();
    $scoreBoard.hide();

    function showSubmitForm(handler) {
        $submitForm.show();
        var $submitBox = $container.find('#input-submit-name');
        $submitBox.focus();
        $("#btn-submit-name").click(function () {
            handler($submitBox.val());
        });
    }

    function hideSubmitForm() {
        $submitForm.hide();
    }

    function enableInput(handler) {
        $inputBox.change(function () {
            handler(this.value);
        });
    }

    function updateScoreTable(scores) {
        var $scoreList = $container.find('#scoreList');
        $scoreList.empty();
        $scoreList.append('<li><span class="title">Name</span><span class="title">Guesses</span></li>');
        scores.forEach(function (entry) {
            $scoreList.append('<li><span>' + entry.name + '</span><span>' + entry.score + '</span></li>');
        });
        $scoreBoard.show();
    }

    function printEnd(text) {
        // $inputBox.hide();
        $inputBox.prop('disabled', true);
        //$outputBox.empty();
        print(text);
    }

    function print(text) {
        $outputBox.append('<li>' + text + '</li>');
    }

    return {
        print: print,
        printEnd: printEnd,
        showSubmitForm: showSubmitForm,
        hideSubmitForm: hideSubmitForm,
        updateScoreTable: updateScoreTable,
        enableInput: enableInput
    }
});