define(function ($) {
    'use strict';

    var data = (function () {
        
         var items = [
             { id: 1, name: "Argentina", src: "http://upload.wikimedia.org/wikipedia/commons/thumb/1/1a/Flag_of_Argentina.svg/200px-Flag_of_Argentina.svg.png" }, 
             { id: 2, name: "Brazil", src: "http://upload.wikimedia.org/wikipedia/en/thumb/0/05/Flag_of_Brazil.svg/200px-Flag_of_Brazil.svg.png" },
             { id: 3, name: "Germany", src: "http://upload.wikimedia.org/wikipedia/en/thumb/b/ba/Flag_of_Germany.svg/200px-Flag_of_Germany.svg.png" }
         ];

        return {
            items: items
        }

    })();

    return data;
});