define(["jquery"], function ($) {

    var $wrapper = $("#mainContent");

    function _load(file) {
        // jQuery.get() returns a promise, so the function returns a promise
        return $.get("views/" + file + ".html", function (data) {
            $wrapper.html(data);
        });
    }

    function load(view) {
        // jQuery.when() returns a promise, so the function returns a promise
        return $.when($wrapper.html(partials[view]));

    }

    var partials = {
        sendMessage: '' +
            '<div class="col-lg-8">' +
            '    <h2>Send Message</h2>' +
            '    <div>' +
            '        <div class="form-group">' +
            '            <label>Name</label>' +
            '            <input id="input-user" class="form-control" type="text" autofocus name="user" placeholder="Enter your nickname here...">' +
            '        </div>' +
            '        <div class="form-group">' +
            '            <label>Message</label>' +
            '            <input id="input-text" class="form-control" type="text" name="text" placeholder="Type your message...">' +
            '        </div>' +
            '        <button type="submit" id="btn-submit" class="btn btn-primary">Send Message</button>' +
            '    </div>' +
            '</div>',
        viewMessages: '' +
            '<div class="col-lg-8">' +
            '     <ul id="messages" data-template="messages-template" class="list-group"></ul>' +
            '</div>' +
            '<script id="messages-template" type="text/x-handlebars-template">' +
            '    {{#items}}' +
            '    <li id="{{id}}" class="list-group-item">' +
            '        <strong>{{by}}</strong><span>: {{{text}}}</span>' +
            '    </li>' +
            '    {{/items}}' +
            '</script>'
    };

    return {
        load: load
    }
});