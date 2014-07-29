define(["jquery", "requester"], function ($, requester) {

    var baseURL = "http://crowd-chat.herokuapp.com/posts";

    function postMessage(message) {
        return requester.postJSON(baseURL, message);
    }

    function getMessages() {
        return requester.getJSON(baseURL);
    };

    return {
        postMessage: postMessage,
        getMessages: getMessages
    }
});