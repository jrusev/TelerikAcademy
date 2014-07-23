define(["jquery"], function ($) {
    'use strict';

    var $container = $('#container');
    var $outputBox = $container.find('#output');
    var $submitBox = $container.find('#submit');

    hideSubmitForm();
    $container.find('#scoreBoard').hide();

    function showSubmitForm(handler) {
        $submitBox.show().focus().change(handler);
    }

    function hideSubmitForm() {
        $submitBox.hide();
    }

    function disableInput() {
        $container.find('#input').prop('disabled', true);
    }

    function updateScoreTable(scores) {
        var $scoreList = $container.find('#scoreList');
        $scoreList.empty();
        scores.forEach(function (entry) {
            $scoreList.append('<li>' + entry.name + ' -> ' + entry.score + '</li>');
        });
        $container.find('#scoreBoard').show();
    }

    function print(text) {
        $outputBox.append('<li>' + text + '</li>');
    }

    return {
        print: print,
        showSubmitForm: showSubmitForm,
        hideSubmitForm: hideSubmitForm,
        updateScoreTable: updateScoreTable,
        disableInput: disableInput
    }

});