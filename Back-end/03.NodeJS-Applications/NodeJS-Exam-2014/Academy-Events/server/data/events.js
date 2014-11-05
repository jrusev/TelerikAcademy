var Event = require('mongoose').model('Event');

module.exports = {
    create: function(event, callback) {
        Event.create(event, callback);
    },
    find: function(criteria, sortBy, callback) {        
        Event.find(criteria)
            .populate('owner', 'username firstName lastName phone')
            .sort(sortBy)
            .exec(callback); 
    },
    findOne: function(criteria, callback) {        
        Event.findOne(criteria)
            .populate('owner', 'username firstName lastName phone')
            .exec(callback); 
    },
    update: function(fileId, update, callback) {  
        Event.findOneAndUpdate({ _id: fileId }, update, callback);
    },
    delete: function(fileId, callback) {  
        Event.remove({ _id: fileId }, callback);
    },
    count: function(criteria, callback) {
        Event.count(criteria, callback);
    }
};