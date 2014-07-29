define(["jquery", "underscore", "persister", "viewLoader", "timer"], function ($, _, persister, viewLoader, timer) {

    function loadSendMessage() {
        timer.stopUpdating();
        viewLoader.load("sendMessage").then(_attachEvents);
    }

    function _attachEvents() {
        $("#btn-submit").on("click", function (event) {
            event.preventDefault();
            var message = {
                "user": $("#input-user").val(),
                "text": $("#input-text").val()
            };
            if (!_isValidName(message.user))
                return alert('What kind of name is that?');

            persister.postMessage(message)
                .then(function () {
                    window.location.hash = "#/";
                });
        });
    }

    function _isValidName(username) {
        var isValid = username && typeof username == 'string' &&
            username.length >= 4 && username.length <= 20;
        return isValid;
    }

    function _updateMessages() {
        persister.getMessages()
            .then(function (messages) {
                var filteredMessages = _.last(messages, 20).reverse();
                $("#messages").loadTemplate(filteredMessages);
            });
    };

    function loadViewMessages() {
        viewLoader.load("viewMessages")
            .then(function () {
                _updateMessages();
                timer.beginUpdating(_updateMessages);
            });
    }

    return {
        loadSendMessage: loadSendMessage,
        loadViewMessages: loadViewMessages
    }
});