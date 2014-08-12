define(["jquery", "underscore", "persister", "viewLoader", "timer"], function ($, _, persister, viewLoader, timer) {

    var sortByTitle = false,
        sortAscending = false,
        numPosts = Number.MAX_VALUE;

    function loadSendPost() {
        if (!persister.isLoggedIn()) {
            alert('Visitors must be logged in in order to post!');
            window.location.hash = "#/login";
            return;
        }
        //timer.stopUpdating();
        _loadNavBar();
        viewLoader.load("sendPost").then(_attachEventsSend);
    }

    function _attachEventsSend() {
        $("#btn-submit").on("click", function (event) {
            event.preventDefault();
            var message = {
                "title": $("#input-title").val(),
                "body": $("#input-text").val()
            };
            if (!message.title)
                return alert('You should have a title!');

            if (!message.body)
                return alert('You should enter some text!');

            persister.sendPost(message)
                .then(function () {
                    window.location.hash = "#/";
                });
        });
    }

    // Username's length must be between 6 and 40 symbols, inclusive.
    function _isValidName(username) {
        var isValid = username && typeof username == 'string' &&
            username.length >= 6 && username.length <= 40;
        return isValid;
    }

    function _loadNavBar() {
        if (persister.isLoggedIn())
            viewLoader.load("navbar-logged", ".navbar");
        else
            viewLoader.load("navbar-not-logged", ".navbar");
    }

    function loadViewPosts() {
        _loadNavBar();
        viewLoader.load("viewPosts")
            .then(_attachEventsView)
            .then(function () {
                _updatePosts();
                //timer.beginUpdating(_updatePosts);
            });
    }

    function _attachEventsView() {
        $("#select-sortby").on("change", function (event) {
            event.preventDefault();
            var sortByOption = $('#select-sortby :selected').text();
            sortByTitle = (sortByOption === 'Sort by title');
            _updatePosts();
        });
        $("#select-sortorder").on("change", function (event) {
            event.preventDefault();
            var sortorderOption = $('#select-sortorder :selected').text();
            sortAscending = (sortorderOption === 'Sort ascending');
            _updatePosts();
        });
        $("#select-num-posts").on("change", function (event) {
            event.preventDefault();
            var value = $(this).find(':selected').val();
            numPosts = (value == 6) ? Number.MAX_VALUE : (value * 10);
            _updatePosts();
        });
    }

    function _updatePosts() {
        persister.getPosts()
            .then(function (posts) {
                if (sortByTitle)
                    posts = _.sortBy(posts, 'title');
                else
                    posts = _.sortBy(posts, 'postDate').reverse();

                if (sortAscending)
                    posts = posts.reverse();

                posts = _.take(posts, numPosts);

                $("#messages").loadTemplate(posts);
            });
    };

    function sortPosts(posts, byProperty, ascending, numPosts) {
        var sorted;
        sorted = _.sortBy(posts, byProperty);
        if (ascending)
            sorted = sorted.reverse();
        sorted = _.take(sorted, numPosts);
        return sorted;
    }

    function loadLoginForm() {
        if (persister.isLoggedIn())
            return window.location.hash = "#/";
        //timer.stopUpdating();
        _loadNavBar();
        viewLoader.load("login").then(_attachEventsLogin);
    }

    function setGreeting() {
        if (persister.isLoggedIn())
            $("#greeting").html('Hello, ' + persister.getUsername() + '!').removeClass('hidden');
        else
            $("#greeting").addClass('hidden');
    }

    function _attachEventsLogin() {
        $("#btn-submit").on("click", function (event) {
            event.preventDefault();
            var username = $("#input-username").val();
            var pass = $("#input-pass").val();

            var authCode = CryptoJS.SHA1(username + pass).toString();
            var data = {
                "username": username,
                "authCode": authCode
            };

            if (!_isValidName(username))
                return alert('Username must be between 6 and 40 symbols!');

            persister.loginUser(data)
                .then(function () {
                        //alert('Successful login!');
                        setGreeting();
                        window.location.hash = "#/";
                    },
                    function (err) {
                        alert(JSON.stringify(err));
                    });
        });
    }

    function loadRegisterForm() {
        //timer.stopUpdating();
        _loadNavBar();
        viewLoader.load("register").then(_attachEventsRegister);
    }

    function _attachEventsRegister() {
        $("#btn-submit").on("click", function (event) {
            event.preventDefault();
            var username = $("#input-username").val();
            var pass = $("#input-pass").val();

            var authCode = CryptoJS.SHA1(username + pass).toString();
            var data = {
                "username": username,
                "authCode": authCode
            };

            if (!_isValidName(username))
                return alert('What kind of name is that?');

            persister.registerUser(data)
                .then(function () {
                    alert('Successful register!');
                    window.location.hash = "#/";
                }, function (err) {
                    alert(JSON.stringify(err));
                });
        });
    }

    function logout() {
        if (!persister.isLoggedIn())
            return alert('You are not logged in!');
        _loadNavBar();
        persister.logout()
            .then(function () {
                alert('Successful logout!');
                setGreeting();
                window.location.hash = "#/";
            }, function (err) {
                alert(JSON.stringify(err));
            });
    }

    function loadSearch() {
        _loadNavBar();
        //timer.stopUpdating();
        viewLoader.load("search").then(_attachEventsSearch);
    }

    function _attachEventsSearch() {
        $("#btn-submit").on("click", function (event) {
            event.preventDefault();
            var pattern = $("#input-pattern").val();
            var username = $("#input-username").val();
            _loadFilteredMessages(pattern, username);
        });
    }

    function _loadFilteredMessages(pattern, username) {
        viewLoader.load("viewPosts")
            .then(_attachEventsView)
            .then(function () {
                persister.search(pattern, username)
                    .then(function (posts) {
                        if (posts.length == 0)
                            alert('No results found matching your query.');
                        $("#messages").loadTemplate(posts.reverse());
                    }, function (err) {
                        alert(JSON.stringify(err));
                    });
            });
    }

    return {
        loadSendPost: loadSendPost,
        loadViewPosts: loadViewPosts,
        loadLoginForm: loadLoginForm,
        loadRegisterForm: loadRegisterForm,
        logout: logout,
        loadSearch: loadSearch,
        setGreeting: setGreeting,
        sortPosts: sortPosts
    }
});