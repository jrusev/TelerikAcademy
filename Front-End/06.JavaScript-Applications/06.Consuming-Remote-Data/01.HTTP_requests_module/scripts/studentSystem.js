define(['jquery', 'ui', 'JSONrequest'], function ($, ui, JSONrequest) {
    'use strict';

    var resourceUrl = 'http://localhost:3000/students';

    function loadStudents() {
        return JSONrequest
            .getJSON(resourceUrl)
            .done(ui.successLoadStudents)
            .fail(ui.errorHandler);
    };

    function addStudent(data) {
        return JSONrequest
            .postJSON(resourceUrl, data)
            .done(ui.successAddStudent)
            .done(loadStudents)
            .fail(ui.errorHandler);
    };

    return {
        loadStudents: loadStudents,
        addStudent: addStudent
    }

});