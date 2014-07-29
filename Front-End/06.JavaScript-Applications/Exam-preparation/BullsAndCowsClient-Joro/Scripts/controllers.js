/// <reference path="class.js" />
/// <reference path="data-layer.js" />
/// <reference path="ui-controls.js" />
/// <reference path="q.js" />
var BullsAndCows = BullsAndCows || {};

BullsAndCows.Controllers = (function () {
    var AccessController = Class.create({
        init: function (dataPersister, mainContainerSelector) {
            this.dataPersister = dataPersister;

            this.mainContainerSelector = mainContainerSelector;
            this.loginControl = null;
            this.registerControl = null;
        },

        isUserLoggedIn: function () {
            return this.dataPersister.isUserLoggedIn();
        },

        getUserData: function () {
            return dataPersister.getUserData();
        },

        loginUser: function () {
            var loginDeferred = Q.defer();

            this.handleLoginProcedure(loginDeferred);

            return loginDeferred.promise;
        },

        logoutUser: function () {
            this.dataPersister.user.logout();
        },

        handleLoginProcedure: function (deferred) {
            var self = this;

            self.loginControl = new BullsAndCows.UI.LoginControl();

            var mainContainer = $(this.mainContainerSelector);

            self.loginControl.build(this.mainContainerSelector).then(function () {
                self.loginControl.attachLoginClickHandler(function (loginData) {
                    self.dataPersister.user.login(loginData.username, loginData.password).then(function () {
                        deferred.resolve();
                    },
                    function (error) {
                        self.loginControl.reportError(error.responseText);
                    })
                }, true);

                mainContainer.append("<a href='#' id='go-to-register'>Register</a>");
                $("#go-to-register").on("click", function () {
                    self.handleRegisterProcedure(deferred);
                    return false;
                })
            }).done();

        },

        handleRegisterProcedure: function (deferred) {
            var self = this;

            self.registerControl = new BullsAndCows.UI.RegisterControl();

            var mainContainer = $(this.mainContainerSelector);

            self.registerControl.build(this.mainContainerSelector).then(function () {
                self.registerControl.attachRegisterClickHandler(function (registerData) {
                    self.dataPersister.user.register(registerData.username, registerData.nickname, registerData.password).then(function () {
                        deferred.resolve();
                    }, function (error) {
                        self.registerControl.reportError(error.responseText);
                    });
                }, true);

                mainContainer.append("<a href='#' id='go-to-login'>Login</a>");
                $("#go-to-login").on("click", function () {
                    self.handleLoginProcedure(deferred);
                    return false;
                })
            }).done();
        }

    });

    var GameController = Class.create({
        init: function (dataPersister, mainContainerSelector) {
            this.dataPersister = dataPersister;

            this.mainContainerSelector = mainContainerSelector;

            this.openGamesList = new BullsAndCows.UI.ListControl();
            this.activeGamesList = new BullsAndCows.UI.ListControl();
            this.createdGamesList = new BullsAndCows.UI.ListControl();
            this.gameStateGrid = new BullsAndCows.UI.GridViewControl();
            this.createGameControl = new BullsAndCows.UI.CreateGameControl();
            this.messagesList = new BullsAndCows.UI.ListControl();
            this.makeGuessControl = new BullsAndCows.UI.GuessControl();
            this.joinGameControl = null;

            this._joinGameIndex = -1;
            this._scheduledDataUpdates = new Array();
            this._userData = {};
            this._activeGames = {};
            this._openGames = {};
            this._gameUserGuesses = {};
            this._gameOpponentGuesses = {};
            this._currentGameId = -1;
            this._messages = {};
        },

        startGame: function () {
            this.stopGame();
            this._userData = this.dataPersister.user.getCurrentUserData();
            var self = this;
            this.initializeControls().then(function () {
                self.attachHandlers();
                self.scheduleDataUpdates();
            });
        },

        initializeControls: function () {

            var self = this;

            $(this.mainContainerSelector).append("<p>Logged in as " + this._userData.nickname + " [" + this._userData.username + "]</p>");

            this.createGameControl.build(self.mainContainerSelector);

            var promisesArr = new Array();

            //TODO: the following are async, put in array with .all or .then each of them
            promisesArr.push(
            self.openGamesList.build(self.mainContainerSelector, "Open Games", [], "title")
            );

            promisesArr.push(
            self.activeGamesList.build(self.mainContainerSelector, "Active/Full Games", [], "title")
            );

            self.dataPersister.games.getOpen().then(function (gamesData) {
                self.openGamesList.changeData(gamesData, "title");
            }).done();

            self.dataPersister.games.getCurrentUserActive().then(function (gamesData) {
                self.activeGamesList.changeData(gamesData, "title");
            }).done();

            promisesArr.push(
            self.makeGuessControl.build(self.mainContainerSelector).then(function () {
                self.makeGuessControl.hide();
                self.gameStateGrid.build(self.mainContainerSelector, "", ["Your guesses", "Bulls", "Cows", "Opponent guesses", "Bulls", "Cows"], [[]]);

                if (self._currentGameId != -1) {
                    self.updateCurrentGame();
                }
            })
            );

            return Q.all(promisesArr);
        },

        attachHandlers: function () {
            var self = this;

            this.createGameControl.attachCreateClickHandler(function (gameCreateData) {
                self.dataPersister.games.create(gameCreateData.title, gameCreateData.number, gameCreateData.password)
                    .then(function () {
                        self.createGameControl.clearErrorReport();
                        self.createGameControl.reportSuccess("Game created successfully and will be listed when joined");
                    }, function (error) {
                        self.createGameControl.clearErrorReport();
                        self.createGameControl.reportError(error.responseText);
                    }).done();
            });

            this.activeGamesList.attachItemClickHandler(function (itemData) {
                var clickedActiveGameData = self._activeGames[itemData.itemIndex];

                if (clickedActiveGameData.status == "full" && clickedActiveGameData.creatorNickname == self._userData.nickname) {
                    self.dataPersister.games.start(clickedActiveGameData.id).then(function () {
                        self._currentGameId = clickedActiveGameData.id;
                        self.updateCurrentGame();
                    });
                }

                else {
                    self._currentGameId = clickedActiveGameData.id;
                    self.updateCurrentGame();
                }
            });

            this.makeGuessControl.attachGuessClickHandler(function (guessData) {
                self.dataPersister.guesses.make(guessData.number, self._currentGameId).then(function () {
                    self.updateCurrentGame();
                }).done();
            });

            this.openGamesList.attachItemClickHandler(function (itemData) {
                if (self._joinGameIndex != itemData.itemIndex) {
                    if (self.joinGameControl) {
                        self.joinGameControl.deleteFromDom();
                    }

                    self._joinGameIndex = itemData.itemIndex;
                    self.joinGameControl = new BullsAndCows.UI.JoinGameControl();
                    self.joinGameControl.buildAfterContent(itemData.item).then(function () {
                        self.stopDataUpdates();

                        self.joinGameControl.attachJoinClickHandler(function (joinData) {
                            var gameId = self._openGames[itemData.itemIndex].id;
                            self.dataPersister.games.join(gameId, joinData.number, joinData.password).then(function () {
                                self.scheduleDataUpdates();
                                self.joinGameControl.deleteFromDom();
                                self._joinGameIndex = -1;

                                self._currentGameId = gameId;
                                self.updateCurrentGame();
                            });
                        });
                    }).done();
                }
            });
        },

        updateCurrentGame: function () {
            var self = this;

            this.dataPersister.games.getState(this._currentGameId).then(function (gameData) {
                self.processCurrentGameData(gameData);
            });
        },

        //updateActiveAndCreated

        scheduleDataUpdates: function () {
            var self = this;

            this._scheduledDataUpdates.push(setInterval(function () {
                self.dataPersister.games.getOpen().then(function (games) {
                    self._openGames = games;
                    self.openGamesList.changeData(self._openGames, "title")
                }).done();
            }, 2000));

            this._scheduledDataUpdates.push(setInterval(function () {
                self.dataPersister.games.getCurrentUserActive().then(function (activeGames) {
                    self.processActiveGamesData(activeGames);
                }).done();
            }, 2000));

            this._scheduledDataUpdates.push(setInterval(function(){
                self.dataPersister.messages.getUserUnread().then(function (messages) {
                    for (var i in messages) {
                        if (messages[i].gameId == self._currentGameId) {
                            self.updateCurrentGame();
                        }
                    }
                }).done();
            }));
        },

        processCurrentGameData: function (gameData) {
            var userColor = "";

            if (this._userData.username == gameData.red) {
                this._gameUserGuesses = gameData.redGuesses;
                this._gameOpponentGuesses = gameData.blueGuesses;
                userColor = "red";
            }
            else {
                this._gameUserGuesses = gameData.blueGuesses;
                this._gameOpponentGuesses = gameData.redGuesses;
                userColor = "blue";
            }

            if (this._gameUserGuesses.length < this._gameOpponentGuesses.length) {
                this._gameUserGuesses.push({ number: "", bulls: "", cows: "" });
            }
            else if (this._gameUserGuesses.length > this._gameOpponentGuesses.length) {
                this._gameOpponentGuesses.push({ number: "", bulls: "", cows: "" });
            }

            var guessesTable = new Array();
            for (var i in this._gameUserGuesses) {
                var currUserGuess = this._gameUserGuesses[i];
                var currOpponentGuess = this._gameOpponentGuesses[i];
                var row = new Array(currUserGuess.number, currUserGuess.bulls, currUserGuess.cows,
                    currOpponentGuess.number, currOpponentGuess.bulls, currOpponentGuess.cows);
                guessesTable.push(row);
            }

            this.gameStateGrid.mainHeader = "Game \"" + gameData.title + "\"";
            this.gameStateGrid.changeData(guessesTable);

            if (gameData.inTurn == userColor) {
                this.makeGuessControl.show();
            }
            else {
                this.makeGuessControl.hide();
            }
        },

        processActiveGamesData: function (activeGames) {
            for (i in activeGames) {
                if (activeGames[i].status == "full" && activeGames[i].creatorNickname == this._userData.nickname) {
                    activeGames[i].representation = activeGames[i].title + " - click to start";
                }
                else {
                    if (activeGames[i].id == this._currentGameId) {
                        activeGames[i].representation = activeGames[i].title;
                    }
                    activeGames[i].representation = activeGames[i].title;
                }
            }

            this._activeGames = activeGames;
            this.activeGamesList.changeData(activeGames, "representation");
        },

        stopDataUpdates: function () {
            for (i in this._scheduledDataUpdates) {
                var intervalId = this._scheduledDataUpdates[i];
                clearInterval(intervalId);
            }
        },

        stopGame: function () {
            this.stopDataUpdates();

            this._scheduledDataUpdates = new Array();
        }
    });

    return {
        getAccessController: function (dataPersister, mainContainerSelector) { return new AccessController(dataPersister, mainContainerSelector); },
        getGameController: function (dataPersister, mainContainerSelector) { return new GameController(dataPersister, mainContainerSelector); }
    }
}());