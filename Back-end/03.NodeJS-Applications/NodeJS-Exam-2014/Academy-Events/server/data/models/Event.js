var mongoose = require('mongoose');

module.exports.init = function() {
    
    var eventSchema = mongoose.Schema({
        title: { type: String, require: '{PATH} is required'},
        description: { type: String, require: '{PATH} is required'},
        location: String,
        date: Date,
        category: String,
        type: String,
        initiative: String,
        season: String,
        comments: [String],
        owner : {
            type: mongoose.Schema.Types.ObjectId,
            ref: 'User'
        }
    });

    var Event = mongoose.model('Event', eventSchema);
};