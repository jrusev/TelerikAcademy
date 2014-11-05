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
    },
    update: function(userId, update, callback) {  
        User.findOneAndUpdate({ _id: userId }, update, callback);
    },
    findOne: function(criteria, callback) {        
        User.findOne(criteria)
            //.populate({ path: 'joinedEvents' })
            .exec(callback); 
    }
};