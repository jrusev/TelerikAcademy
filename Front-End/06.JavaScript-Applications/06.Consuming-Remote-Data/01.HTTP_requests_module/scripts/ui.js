define(['jquery'], function ($) {
    'use strict';

    var $successMsg, $errorMsg;

    $(function () {
        $successMsg = $('.messages .success');
        $errorMsg = $('.messages .error');
    });

    function successAddStudent(data) {
        $successMsg.html('' + data.name + ' successfully added').show().fadeOut(2000);
    };

    function successLoadStudents(data) {
        var student, $studentsList, i, len;
        $studentsList = $('<ul/>').addClass('students-list');
        for (i = 0, len = data.students.length; i < len; i++) {
            student = data.students[i];
            $studentsList
                .append('<li>Name: ' + student.name + ', Grade: ' + student.grade + '</li>');
        }
        $('#students-container').html($studentsList);
    };

    function errorHandler(err) {
        console.log('Error: ' + JSON.stringify(err));
        $errorMsg
            .html('Error: ' + err.status + ' (' + err.statusText + ')')
            .show()
            .fadeOut(2000);
    };

    function attachHandler(handler) {
        $('#btn-add-student').on('click', function () {
            var student = {
                name: $('#tb-name').val(),
                grade: $('#tb-grade').val()
            };
            handler(student);
        });
    }

    return {
        successAddStudent: successAddStudent,
        successLoadStudents: successLoadStudents,
        errorHandler: errorHandler,
        attachHandler: attachHandler
    }

});