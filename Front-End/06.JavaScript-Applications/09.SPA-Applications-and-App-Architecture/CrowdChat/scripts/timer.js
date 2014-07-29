define(function () {

    var refreshIntervalMS = 2000,
        intervalID = false;

    function beginUpdating(callBack) {
        if (!intervalID) {
            intervalID = window.setInterval(callBack, refreshIntervalMS);
        }
    }

    function stopUpdating() {
        if (intervalID) {
            window.clearInterval(intervalID);
            intervalID = false;
        }
    }

    return {
        beginUpdating: beginUpdating,
        stopUpdating: stopUpdating
    }
});