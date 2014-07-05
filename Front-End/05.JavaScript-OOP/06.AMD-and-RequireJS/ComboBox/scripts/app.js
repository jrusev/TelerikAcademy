(function () {

    require.config({
        paths: {
            "jquery": "libs/jquery-2.1.1.min",
            "handlebars": "libs/handlebars-v1.3.0"
        }
    });

    require(["jquery", "controls"], function ($, controls) {
        
         var items = [
             { id: 1, name: "Argentina", src: "http://upload.wikimedia.org/wikipedia/commons/thumb/1/1a/Flag_of_Argentina.svg/200px-Flag_of_Argentina.svg.png" }, 
             { id: 2, name: "Brazil", src: "http://upload.wikimedia.org/wikipedia/en/thumb/0/05/Flag_of_Brazil.svg/200px-Flag_of_Brazil.svg.png" },
             { id: 3, name: "Germany", src: "http://upload.wikimedia.org/wikipedia/en/thumb/b/ba/Flag_of_Germany.svg/200px-Flag_of_Germany.svg.png" }
         ];  

        $(document).ready(function () {
            var comboBox = controls.ComboBox(items);
            var template = $("#template").html();
            var comboBoxHtml = comboBox.render(template);
            $('#container').html(comboBoxHtml);
        });
    });

}());