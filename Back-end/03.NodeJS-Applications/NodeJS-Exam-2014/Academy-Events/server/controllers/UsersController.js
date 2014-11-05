var encryption = require('../utilities/encryption'),
    users = require('../data/users');

var moment = require('moment');

var events = require('../data/events');

var initiatives = require('../data/initiatives');

var CONTROLLER_NAME = 'users';
var CONSTANTS = {	
	USERNAME: {
		VALID_CHARS: 'qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890_.'.split(''),
		MIN_LENGTH: 6,
		MAX_LENGTH: 20
	},
};

function isUsernameValid(username) {
	if (!username ||
		username.length < CONSTANTS.USERNAME.MIN_LENGTH ||
		CONSTANTS.USERNAME.MAX_LENGTH < username.length) {
		return false;
	}
	var validChars = CONSTANTS.USERNAME.VALID_CHARS;
	for (var i = 0, len = username.length; i < len; i += 1) {
		var ch = username[i];
		if (validChars.indexOf(ch) < 0) {
			return false;
		}
	}

	return true;
}

module.exports = {
    getRegister: function(req, res, next) {
        res.render(CONTROLLER_NAME + '/register', {initiatives: JSON.stringify(initiatives)})
    },
    postRegister: function(req, res, next) {
        var newUserData = req.body;        

        var userInitiatives = [];
        newUserData.initiatives.forEach(function(i) {
            userInitiatives.push(initiatives.all[+i]);
        })
        
        newUserData.initiatives = userInitiatives;
        newUserData.joinedEvents = [];
        
        console.log(userInitiatives)

        if (!isUsernameValid(newUserData.username)) {
            req.session.error = "The username should be between 6 and 20 characters long and can contain Latin letters, digits and the symbols '_' (underscore), ' ' (space) and '.' (dot)!";
            return res.redirect('/register');
        }
        
        if (!newUserData.password || newUserData.password.length === 0) {
            req.session.error = 'You must provide a password!';
            return res.redirect('/register');
        }
        
        if (newUserData.password != newUserData.confirmPassword) {
            req.session.error = 'Passwords do not match!';
            return res.redirect('/register');
        }
        
        newUserData.salt = encryption.generateSalt();
        newUserData.hashPass = encryption.generateHashedPassword(newUserData.salt, newUserData.password);
        users.create(newUserData, function(err, user) {
            if (err) {
                console.log('Failed to register new user: ' + err);
                return;
            }

            req.logIn(user, function(err) {
                if (err) {
                    res.status(400);
                    return res.send({reason: err.toString()}); // TODO
                }
                else {
                    res.redirect('/');
                }
            })
        });
        
    },
    getLogin: function(req, res, next) {
        res.render(CONTROLLER_NAME + '/login');
    },
    getProfile: function(req, res, next) {
        // function(criteria, sortBy, callback)
        events.find({owner: req.user._id}, {'date' : 'desc'}, function (err, ownEvents) {
            
            users.findOne({_id: req.user._id}, function (err, user) {
                
                var joinedEvents = user.joinedEvents;

                res.render(CONTROLLER_NAME + '/profile', {
                    user: req.user,
                    ownEvents: ownEvents,
                    joinedEvents: JSON.stringify(joinedEvents),
                    moment: moment
                });
            });
            
        });
        
    },
    postProfile: function(req, res, next) {
        var newUserData = req.body;  
        var user = req.user;
        
        var update = {
            imageUrl: newUserData.imageUrl || user.imageUrl,
            phone: newUserData.phone || user.phone,
            facebookUrl: newUserData.facebookUrl || user.facebookUrl,
            googleUrl: newUserData.googleUrl || user.googleUrl,
            linkedInUrl: newUserData.linkedInUrl || user.linkedInUrl            
        };
        
        users.update(req.user, update, function (err) {
            if (err) 
                return res.status(400).send({ message: 'User cannot be updated', err: err});
            //res.send('Profile updated');  
            res.redirect('/profile');
        });    
    },
};