define(['underscore', 'uiManager'], function (_, ui) {
	'use strict';

	var SIZE = 4,
		digits = "123456789",
		secret = _.sample(digits, SIZE),
		countGuesses = 0,
		gameEnded = false;

	console.log(secret.join(''));

	function onGuess(evt) {
		if (gameEnded) return;
		var guess = this.value;
		if (_.intersection(guess, digits).length !== SIZE)
			return ui.print('Invalid guess, try again.');

		countGuesses++;
		var bulls = _.reduce(_.zip(guess, secret), function (count, p) {
			return p[0] == p[1] ? count + 1 : count;
		}, 0);

		if (bulls == SIZE)
			return endGame(guess);

		var cows = _.intersection(guess, secret).length - bulls;
		ui.print(guess + ': ' + bulls + ' bulls, ' + cows + ' cows');
	}

	function endGame(guess) {
		ui.print(guess + ': Correct, you guessed it from ' + countGuesses + ' guesses!');
		ui.print('Please enter your nickname in the input box...')
		gameEnded = true;
		ui.showSubmitForm(countGuesses);
	}
	
	return {
		onGuess: onGuess
	}
});