define(['jquery', 'ui'], function ($, ui) {
    'use strict';

    var resourceUrl = 'http://localhost:3000/students';

    function loadStudents() {
        return $.get(resourceUrl)
            .done(ui.showStudents)
            .fail(ui.showError);
    };

    function addStudent(name, grade) {
        var student = {
            name: name,
            grade: grade
        };
        return $.post(resourceUrl, student)
            .done(ui.successAddStudent)
            .done(loadStudents)
            .fail(ui.showError);
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
            .fail(ui.showError);
    }

    return {
        loadStudents: loadStudents,
        addStudent: addStudent,
        removeStudent: removeStudent
    }
});