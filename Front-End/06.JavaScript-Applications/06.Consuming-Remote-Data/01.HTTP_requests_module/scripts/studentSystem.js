(function ($) {
    'use strict';

    var resourceUrl = 'http://localhost:3000/students',
        $successMessage = $('.messages .success'),
        $errorMessage = $('.messages .error');

    var successAddStudent = function (data) {
        $successMessage
            .html('' + data.name + ' successfully added')
            .show()
            .fadeOut(2000);
        loadStudents();
    };

    var successLoadStudents = function (data) {
        var student, $studentsList, i, len;
        $studentsList = $('<ul/>').addClass('students-list');
        for (i = 0, len = data.students.length; i < len; i++) {
            student = data.students[i];
            $('<li />')
                .addClass('student-item')
                .append($('<strong /> ')
                    .html(student.name))
                .append($('<span />')
                    .html(student.grade))
                .appendTo($studentsList);
        }
        $('#students-container').html($studentsList);
    };

    var errorHandler = function (err) {
        console.log('Error: ' + JSON.stringify(err));
        $errorMessage
            .html('Error: ' + err.status + ' (' + err.statusText + ')')
            .show()
            .fadeOut(2000);
    };

    var loadStudents = function () {
        return JSONrequest
            .getJSON(resourceUrl)
            .done(successLoadStudents)
            .fail(errorHandler);
    };

    var addStudent = function (data) {
        return JSONrequest
            .postJSON(resourceUrl, data)
            .done(successAddStudent)
            .fail(errorHandler);
    };

    (function () {
        loadStudents();
        $('#btn-add-student').on('click', function () {
            var student;
            student = {
                name: $('#tb-name').val(),
                grade: $('#tb-grade').val()
            };
            addStudent(student);
        });
    })();

})(jQuery);