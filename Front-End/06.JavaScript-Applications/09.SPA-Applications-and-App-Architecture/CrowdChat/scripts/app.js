(function () {
    require.config({
        paths: {
            // Libs
            jquery: "libs/jquery",
            underscore: "libs/underscore-min",
            sammy: "libs/sammy",
            handlebars: "libs/handlebars-v1.3.0",

            // Scripts
            requester: "httpRequester",
            viewLoader: "viewLoader",
            jqueryPlugins: "jqueryPlugins",
            controller: "controller",
            storage: "storage",
            timer: "timer"
        },
        shim: {
            handlebars: {
                exports: 'Handlebars'
            }
        }
    });

    require(["sammy", "controller", "jqueryPlugins"], function (sammy, controller) {
        var app = sammy("#mainContent", function () {

            this.get("#/", function () {
                controller.loadViewMessages();
            });

            this.get("#/send", function () {
                controller.loadSendMessage();
            });
        });

        app.run("#/");
    });
}());