(function () {    
    'use strict';

    require.config({
        paths: {
            "jquery": "libs/jquery-2.1.1.min",
            "handlebars": "libs/handlebars-v1.3.0"
        }
    });

    require(["jquery", "controls", "data"], function ($, controls, data) {
        
        $(document).ready(function () {
            var comboBox = controls.ComboBox(data.countryFlags);
            var template = $("#template").html();
            var comboControl = comboBox.render(template);
            $('#container').append(comboControl);
        });
    });

}());