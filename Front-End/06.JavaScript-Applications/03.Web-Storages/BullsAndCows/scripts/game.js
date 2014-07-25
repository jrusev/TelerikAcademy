define(['underscore', 'uiManager', 'scoreBoard'], function (_, ui, scoreBoard) {
    'use strict';
    var SIZE = 4,
        DIGITS = "123456789",
        secret = _.sample(DIGITS, SIZE),
        countGuesses = 0;
    console.log(secret.join(''));

    function onGuess(guess) {
        if (guess.length !== SIZE || _.intersection(guess, DIGITS).length !== SIZE)
            return ui.print('Invalid guess, try again.');

        countGuesses++;
        var bulls = _.reduce(_.zip(guess, secret), function (count, p) {
            return p[0] == p[1] ? count + 1 : count;
        }, 0);

        if (bulls == SIZE) {
            ui.printEnd(guess + ': Correct, you needed ' + countGuesses + ' guesses!');
            return scoreBoard.saveScore(countGuesses);
        }

        var cows = _.intersection(guess, secret).length - bulls;
        ui.print(guess + ': ' + bulls + ' bulls, ' + cows + ' cows');
    }

    return {
        onGuess: onGuess
    }
});