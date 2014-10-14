var UsersController = require('./UsersController'),
    FilesController = require('./FilesController');
var StatsController = require('./StatsController');

module.exports = {
    users: UsersController,
    files: FilesController,
    stats: StatsController
};