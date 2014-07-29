(function () {
    'use strict';
    require.config({
        paths: {
            mocha: 'libs/mocha',
            chai: 'libs/chai'
        }
    });

    require(['mocha', 'chai'], function () {
        mocha.setup('bdd');
        require(['test.session'], function () {
            mocha.run();
        });
    })
}());