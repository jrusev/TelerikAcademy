/// <reference path="q.js" />
/// <reference path="jquery-2.0.2.js" />
/// <reference path="http-requester.js" />
/// <reference path="class.js" />
var BullsAndCows = BullsAndCows || {}

BullsAndCows.UI = (function () {
    var buildControlPromise = function (controlHtmlUrl, rootElement) {
        var buildDeferred = Q.defer();

        HttpRequester.getJson(controlHtmlUrl).then(function (partialHtml) {
            var container = $("<div class='control-container'>" + partialHtml + "</div>");
            $(rootElement).append(container);
            rootElement = container;

            buildDeferred.resolve(rootElement);
        }, function (error) {
            buildDeferred.reject(error);
        });

        return buildDeferred.promise;
    }

    var LoginControl = Class.create({
        build: function (selector) {
            var self = this;
            self.rootElement = $(selector);

            return buildControlPromise("../login-control.html", this.rootElement).then(function (newRootElement) {
                self.rootElement = newRootElement;
            });
        },

        getUsernameText: function () {
            return $("#login-username-input").val();
        },

        getPasswordText: function () {
            return $("#login-password-input").val();
        },

        attachLoginClickHandler: function (handler, removePreviousHandlers) {

            var self = this;

            if (removePreviousHandlers) {
                $(this.rootElement).off("click");
            }

            this.rootElement.on("click", "#login-button", function () {
                var loginData = {
                    username: self.getUsernameText(),
                    password: self.getPasswordText()
                };

                handler(loginData);
            });
        },

        reportError: function (errorMessage) {
            this.rootElement.append("<p class='error-message' style='color:red'>" + errorMessage + "</p>");
        }
    });

    var RegisterControl = Class.create({
        build: function (selector) {
            var self = this;
            self.rootElement = $(selector);

            return buildControlPromise("../register-control.html", this.rootElement).then(function (newRootElement) {
                self.rootElement = newRootElement;
            });
        },

        getUsernameText: function () {
            return $("#register-username-input").val();
        },

        getPasswordText: function () {
            return $("#register-password-input").val();
        },

        getNicknameText: function () {
            return $("#register-nickname-input").val();
        },

        attachRegisterClickHandler: function (handler, removePreviousHandlers) {
            var self = this;

            if (removePreviousHandlers) {
                $(this.rootElement).off("click");
            }

            $(this.rootElement).on("click", "#register-button", function () {
                var registerData = {
                    username: self.getUsernameText(),
                    nickname: self.getNicknameText(),
                    password: self.getPasswordText()
                };

                handler(registerData);
            });
        },

        reportError: function (errorMessage) {
            this.rootElement.append("<p class='error-message' style='color:red'>" + errorMessage + "</p>");
        }
    });

    var ListControl = Class.create({
        build: function (selector, header, data, dataDisplayPropertyName) {

            var self = this;
            self.rootElement = $(selector);
            self.listElements = new Array();

            return buildControlPromise("../list-control.html", this.rootElement).then(function (newRootElement) {
                self.rootElement = newRootElement;

                self.header = self.rootElement.children("h2.control-header"),
                self.listContainer = self.rootElement.children("ul.control-data-container");

                self.header.text(header);

                self.changeData(data, dataDisplayPropertyName);
            });
        },

        changeData: function (newData, dataDisplayPropertyName) {
            this.listContainer.html("");

            if (newData) {
                for (var i in newData) {
                    var listElement = $("<li>" + newData[i][dataDisplayPropertyName] + "</li>");

                    this.listContainer.append(listElement);

                    this.listElements.push(listElement);
                }
            }
        },

        attachItemClickHandler: function (handler, removePreviousHandlers) {
            var self = this;

            if (removePreviousHandlers) {
                $(this.rootElement).off("click");
            }

            self.rootElement.on("click", "li", function (event) {
                var itemData = {
                    itemIndex: $(this).index(),
                    item: $(this)
                }
                handler(itemData);
            })
        }
    });

    var CreateGameControl = Class.create({
        build: function (selector) {
            var self = this;
            self.rootElement = $(selector);

            return buildControlPromise("../create-game-control.html", this.rootElement).then(function (newRootElement) {
                self.rootElement = newRootElement;
            });
        },

        getTitleText: function () {
            return $("#create-game-title-input").val();
        },

        getNumberText: function () {
            return $("#create-game-number-input").val();
        },

        getPasswordText: function () {
            return $("#create-game-password-input").val();
        },

        attachCreateClickHandler: function (handler, removePreviousHandlers) {

            var self = this;

            if (removePreviousHandlers) {
                $(this.rootElement).off("click");
            }

            $(this.rootElement).on("click", "#create-game-button", function () {
                var gameCreateData = {
                    title: self.getTitleText(),
                    password: self.getPasswordText(),
                    number: parseInt(self.getNumberText())
                };

                handler(gameCreateData);
            });
        },

        reportSuccess: function (message) {
            var successMessage = $("<p class='success-message' style='color:green'>" + message + "</p>");
            this.rootElement.append(successMessage);
            successMessage.fadeOut(2000, function () {
                successMessage.remove();
            });
        },

        reportError: function (errorMessage) {
            this.rootElement.append("<p class='error-message' style='color:red'>" + errorMessage + "</p>");
        },

        clearErrorReport: function () {
            var errorMessages = this.rootElement.children(".error-message");
            errorMessages.fadeOut(200, function () {
                errorMessages.remove();
            });
        }
    });

    var MakeGuessControl = Class.create({
        build: function (selector) {
            
            var self = this;
            self.rootElement = $(selector);

            return buildControlPromise("../make-guess-control.html", this.rootElement).then(function (newRootElement) {
                self.rootElement = newRootElement;
            });
        },

        getNumberText: function () {
            return $("#guess-number-input").val();
        },

        attachGuessClickHandler: function (handler, removePreviousHandlers) {

            var self = this;

            if (removePreviousHandlers) {
                $(this.rootElement).off("click");
            }

            $(this.rootElement).on("click", "#make-guess-button", function () {
                var makeGuessData = {
                    number: parseInt(self.getNumberText())
                };

                handler(makeGuessData);
            });
        },

        show: function(){
            this.rootElement.show();
        },

        hide: function () {
            this.rootElement.hide();
        },

        reportError: function (errorMessage) {
            this.rootElement.append("<p class='error-message' style='color:red'>" + errorMessage + "</p>");
        },

        clearErrorReport: function () {
            this.rootElement.children(".error-message").remove();
        }
    });

    var JoinGameControl = Class.create({
        buildAfterContent: function (listItem) {
            var container = $("<div class='control-container'></div>");
            this.rootElement = container;
            $(listItem).append(container);

            return HttpRequester.getJson("../join-game-control.html").then(function (joinHtml) {
                container.append(joinHtml);
            });
        },

        getRoot: function(){
            return this.rootElement;
        },

        deleteFromDom: function () {
            $("#game-login-container").parent().remove();
        },

        getPasswordText: function () {
            return $("#game-login-password-input").val();
        },

        getNumberText: function () {
            return $("#game-login-number-input").val();
        },

        attachJoinClickHandler: function (handler, removePreviousHandlers) {

            var self = this;

            if (removePreviousHandlers) {
                $(this.rootElement).off("click");
            }

            $(this.rootElement).on("click", "#game-login-button", function () {
                var gameLoginData = {
                    password: self.getPasswordText(),
                    number: parseInt(self.getNumberText())
                };

                handler(gameLoginData);
                return false;
            });
        },

        reportError: function (errorMessage) {
            this.rootElement.append("<p class='error-message' style='color:red'>" + errorMessage + "</p>");
        },

        clearErrorReport: function () {
            this.rootElement.children(".error-message").remove();
        }
    });

    var GridViewControl = Class.create({
        build: function (selector, mainHeader, headers, dataMatrix) {
            var container = $("<div class='control-container'></div>");
            $(selector).append(container);
            this.rootElement = container;

            this.mainHeader = mainHeader;
            this.headers = headers;

            this.changeData(dataMatrix);
        },

        changeData: function (data) {
            var resultHtml = "<h2>" + this.mainHeader + "</h2><table>";

            resultHtml += "<thead>";
            resultHtml += "<tr>";
            for (var i in this.headers) {
                resultHtml += "<th>" + this.headers[i] + "</th>";
            }
            resultHtml += "</tr>";
            resultHtml += "</thead>";

            resultHtml += "<tbody>";
            for (var row in data) {
                var currRow = data[row];
                resultHtml += "<tr>";
                for (var col in currRow) {
                    resultHtml += "<td>" + currRow[col] + "</td>";
                }
                resultHtml += "</tr>";
            }
            resultHtml += "</tbody>";
            resultHtml += "</table>";

            this.rootElement.html(resultHtml);
        }
    });

    return {
        LoginControl: LoginControl,
        RegisterControl: RegisterControl,
        ListControl: ListControl,
        JoinGameControl: JoinGameControl,
        GuessControl: MakeGuessControl,
        CreateGameControl: CreateGameControl,
        GridViewControl: GridViewControl
    }
}())