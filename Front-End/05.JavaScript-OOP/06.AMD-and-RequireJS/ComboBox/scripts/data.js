define(function ($) {
    'use strict';

    var data = (function () {
        
         var countryFlags = [
             { id: 1, name: "Argentina", src: "http://upload.wikimedia.org/wikipedia/commons/thumb/1/1a/Flag_of_Argentina.svg/200px-Flag_of_Argentina.svg.png" }, 
             { id: 2, name: "Belgium", src: "http://upload.wikimedia.org/wikipedia/commons/thumb/6/65/Flag_of_Belgium.svg/200px-Flag_of_Belgium.svg.png" },
             { id: 3, name: "Brazil", src: "http://upload.wikimedia.org/wikipedia/en/thumb/0/05/Flag_of_Brazil.svg/200px-Flag_of_Brazil.svg.png" },
             { id: 4, name: "Germany", src: "http://upload.wikimedia.org/wikipedia/en/thumb/b/ba/Flag_of_Germany.svg/200px-Flag_of_Germany.svg.png" },
             { id: 5, name: "France", src: "http://upload.wikimedia.org/wikipedia/en/thumb/c/c3/Flag_of_France.svg/200px-Flag_of_France.svg.png" },
             { id: 6, name: "Netherlands", src: "http://upload.wikimedia.org/wikipedia/commons/thumb/2/20/Flag_of_the_Netherlands.svg/200px-Flag_of_the_Netherlands.svg.png" },
             { id: 7, name: "Costa Rica", src: "http://upload.wikimedia.org/wikipedia/commons/thumb/f/f2/Flag_of_Costa_Rica.svg/200px-Flag_of_Costa_Rica.svg.png" }
         ];

        return {
            countryFlags: countryFlags
        }

    })();

    return data;
});