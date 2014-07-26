(function () {
    'use strict';

    require.config({
        paths: {
            jquery: "lib/jquery-2.1.1.min",
            JSONrequest: "JSONrequest",
            studentSystem: "studentSystem",
            ui: "ui",
            handlebars: "lib/handlebars-v1.3.0"
        },
        shim: {
            'handlebars': {
                exports: 'Handlebars'
            }
        }
    });

    require(["jquery", "studentSystem", "ui"], function ($, studentSystem, ui) {

        $(document).ready(function () {
            studentSystem.loadStudents();
            ui.attachAddHandler(studentSystem.addStudent)
            ui.attachRemoveHandler(studentSystem.removeStudent);
        });
    });

}());