define(['jquery', 'ui', 'JSONrequest'], function ($, ui, JSONrequest) {
    'use strict';

    var resourceUrl = 'http://localhost:3000/students';

    function loadStudents() {
        return JSONrequest
            .getJSON(resourceUrl)
            .done(ui.successLoadStudents)
            .fail(ui.errorHandler);
    };

    function addStudent(name, grade) {
        var student = {
            name: name,
            grade: grade
        };
        return JSONrequest
            .postJSON(resourceUrl, student)
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
            .done(loadStudents)
            .fail(ui.errorHandler);
    }

    return {
        loadStudents: loadStudents,
        addStudent: addStudent,
        removeStudent: removeStudent
    }

});