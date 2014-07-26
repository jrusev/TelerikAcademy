(function () {
    'use strict';

    require.config({
        paths: {
            jquery: "lib/jquery-2.1.1.min",
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
            studentSystem.reloadStudents();
            ui.attachHandlers(studentSystem.addStudent, studentSystem.removeStudent)
        });
    });

}());