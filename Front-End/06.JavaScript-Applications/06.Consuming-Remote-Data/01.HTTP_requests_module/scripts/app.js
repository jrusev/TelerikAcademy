(function ($) {
    'use strict';

    $(document).ready(function () {
        studentSystem.loadStudents();
        ui.attachHandler(studentSystem.addStudent)
    });

})(jQuery);