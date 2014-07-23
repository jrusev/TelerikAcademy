define([], function () {
    'use strict';

    var scoreBoardKey = 'bullsCowsStorage';

    Storage.prototype.setObject = function (key, obj) {
        this.setItem(key, JSON.stringify(obj));
    };

    Storage.prototype.getObject = function (key) {
        return JSON.parse(this.getItem(key));
    };

    function addScore(name, guesses) {
        var scoreList = getScores();
        scoreList.push({
            name: name,
            score: guesses
        });
        setScores(_.sortBy(scoreList, 'score'));
    }

    function getScores() {
        return localStorage.getObject(scoreBoardKey) || [];
    }

    function setScores(scoreList) {
        localStorage.setObject(scoreBoardKey, scoreList);
    }

    return {
        addScore: addScore,
        getScores: getScores
    }
});