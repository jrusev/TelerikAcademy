define(["jquery"], function ($) {
    'use strict';

    var $container = $('#container'),
        $outputBox = $container.find('#output'),
        $inputBox = $container.find('#input-guess'),
        $submitForm = $container.find('#form-submit-name');

    function showSubmitForm(handler) {
        $submitForm.removeClass('hidden');
        var $submitBox = $container.find('#input-submit-name');
        $submitBox.focus();
        $("#btn-submit-name").click(function () {
            $submitForm.hide();
            handler($submitBox.val());
        });
    }

    function enableInput(handler) {
        $inputBox.change(function () {
            handler(this.value);
        });
    }

    function showScores(scores) {
        var $scoreList = $container.find('#scoreList').empty();
        $scoreList.append('<li><span class="title">Name</span><span class="title">Guesses</span></li>');
        scores.forEach(function (entry) {
            $scoreList.append('<li><span>' + entry.name + '</span><span>' + entry.score + '</span></li>');
        });
        $container.find('#scoreBoard').removeClass('hidden');
    }

    function printEnd(text) {
        $inputBox.prop('disabled', true);
        print(text);
    }

    function print(text) {
        $outputBox.append('<li>' + text + '</li>');
    }

    return {
        print: print,
        printEnd: printEnd,
        showSubmitForm: showSubmitForm,
        showScores: showScores,
        enableInput: enableInput
    }
});