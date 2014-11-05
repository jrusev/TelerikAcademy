var UsersController = require('./UsersController'),
    EventsController = require('./EventsController');
var StatsController = require('./StatsController');

module.exports = {
    users: UsersController,
    events: EventsController,
    stats: StatsController
};