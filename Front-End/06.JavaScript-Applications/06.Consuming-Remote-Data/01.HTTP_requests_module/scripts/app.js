(function () {
    'use strict';

    require.config({
        paths: {
            jquery: "lib/jquery-2.1.1.min",
            JSONrequest: "JSONrequest",
            studentSystem: "studentSystem",
            ui: "ui"
        }
    });

    require(["jquery", "studentSystem", "ui"], function ($, studentSystem, ui) {

        $(document).ready(function () {
            studentSystem.loadStudents();
            ui.attachHandler(studentSystem.addStudent)
        });
    });

}());