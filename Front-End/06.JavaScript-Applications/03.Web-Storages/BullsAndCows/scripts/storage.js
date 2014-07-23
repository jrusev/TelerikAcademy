define([], function () {
    'use strict';

    var scoreBoardKey = 'bullsCowsStorage';

    Storage.prototype.setObject = function (key, obj) {
        this.setItem(key, JSON.stringify(obj));
    };

    Storage.prototype.getObject = function (key) {
        return JSON.parse(this.getItem(key));
    };

    function saveScores(scores) {
        localStorage.setObject(scoreBoardKey, scores);
    }

    function getScores() {
        return localStorage.getObject(scoreBoardKey) || [];
    }

    return {
        saveScores: saveScores,
        getScores: getScores
    }
});