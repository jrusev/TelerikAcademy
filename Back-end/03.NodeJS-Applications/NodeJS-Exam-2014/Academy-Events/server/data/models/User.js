var mongoose = require('mongoose'),
    encryption = require('../../utilities/encryption');

// A student can be part of many initiatives and in different season
// i.e. Peter Petrov can be part of:
// School Academy Season 2011m School Academy Season 2012 and Software Academy Season 2013

module.exports.init = function() {
    var userSchema = mongoose.Schema({
        username: { type: String, require: '{PATH} is required', unique: true },
        firstName: { type: String, require: '{PATH} is required' },
        lastName: { type: String, require: '{PATH} is required' },
        email: String,
        imageUrl: String,
        // optional
        phone: String,
        facebookUrl: String,
        twitterUrl: String,
        linkedInUrl: String,
        googleUrl: String,
        // Telerik Academy initiatives and seasons,
        initiatives: [{name: String, season: String}],  
        organizationPoints: Number,
        venuePoints: Number,
        salt: String,
        hashPass: String,
        joinedEvents: [ 
            { type: mongoose.Schema.Types.ObjectId, ref: 'User' }
        ]
    });

    userSchema.method({
        authenticate: function(password) {
            if (encryption.generateHashedPassword(this.salt, password) === this.hashPass) {
                return true;
            }
            else {
                return false;
            }
        }
    });

    var User = mongoose.model('User', userSchema);
};


