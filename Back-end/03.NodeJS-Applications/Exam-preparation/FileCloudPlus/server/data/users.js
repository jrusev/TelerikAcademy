var User = require('mongoose').model('User');

module.exports = {
    create: function(user, callback) {
        User.create(user, callback);
    },
    find: function(criteria, callback) {        
        User.find(callback);
    },
    count: function(callback) {
        User.count({}, callback);
    }
};