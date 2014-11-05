var events = require('../data/events');

function getStats(req, res, next) {
    var today = new Date();
    events.count({date: { $lt: today }}, function (err, totalEvents) {
        if (err) throw err;        
        res.render('index', {passedEvents: totalEvents });
    });
} 

module.exports = {
    getStats: getStats   
}