(function () {
    require.config({
        paths: {
            // Libs
            jquery: "libs/jquery",
            underscore: "libs/underscore-min",
            sammy: "libs/sammy",
            handlebars: "libs/handlebars-v1.3.0",
            Q: "libs/q",

            // Scripts
            requester: "httpRequester",
            viewLoader: "viewLoader",
            plugins: "plugins",
            controller: "controller",
            timer: "timer"
        },
        shim: {
            handlebars: {
                exports: 'Handlebars'
            }
        }
    });

    require(["sammy", "controller", "plugins"], function (sammy, controller) {

        controller.setGreeting();
        var app = sammy("#mainContent", function () {

            this.get("#/", function () {
                controller.loadViewPosts();
            });

            this.get("#/search", function () {
                controller.loadSearch();
            });

            this.get("#/register", function () {
                controller.loadRegisterForm();
            });

            this.get("#/login", function () {
                controller.loadLoginForm();
            });

            this.get("#/send", function () {
                controller.loadSendPost();
            });

            this.get("#/logout", function () {
                controller.logout();
            });
        });

        app.run("#/");
    });
}());