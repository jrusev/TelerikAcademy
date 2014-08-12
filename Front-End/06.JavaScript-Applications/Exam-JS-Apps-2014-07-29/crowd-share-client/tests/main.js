(function () {
    'use strict';
    require.config({
        paths: {
            mocha: 'libs/mocha',
            chai: 'libs/chai',
            underscore: "../scripts/libs/underscore-min",
        }
    });

    require(['mocha', 'chai'], function () {
        mocha.setup('bdd');
        require(['unitTests'], function () {
            mocha.run();
        });
    })
}());