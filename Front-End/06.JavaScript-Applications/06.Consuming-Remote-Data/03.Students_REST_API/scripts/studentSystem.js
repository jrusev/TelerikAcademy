define(['jquery', 'ui'], function ($, ui) {
    'use strict';

    var resourceUrl = 'http://localhost:3000/students';

    function loadStudents() {
        return $.get(resourceUrl)
            .done(ui.successLoadStudents)
            .fail(ui.errorHandler);
    };

    function addStudent(name, grade) {
        var student = {
            name: name,
            grade: grade
        };
        return $.post(resourceUrl, student)
            .done(ui.successAddStudent)
            .done(loadStudents)
            .fail(ui.errorHandler);
    };

    function removeStudent(id) {
        return $.ajax({
                url: resourceUrl + '/' + id,
                type: 'POST',
                data: {
                    _method: 'delete'
                }
            })
            .done(ui.successRemoveStudent)
            .done(loadStudents)
            .fail(ui.errorHandler);
    }

    return {
        loadStudents: loadStudents,
        addStudent: addStudent,
        removeStudent: removeStudent
    }
});