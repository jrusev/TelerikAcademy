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
            .done(_successAddStudent)
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
            .done(_successRemoveStudent)
            .done(loadStudents)
            .fail(ui.showError);
    }

    function _successAddStudent(data) {
        var msg = '' + data.name + ' successfully added';
        ui.showSuccessMessage(msg);
    };

    function _successRemoveStudent(data) {
        ui.showSuccessMessage('Student successfully removed');
    };

    return {
        loadStudents: loadStudents,
        addStudent: addStudent,
        removeStudent: removeStudent
    }
});