var encryption = require('../utilities/encryption'),
    users = require('../data/users'),
    uploading = require('../utilities/uploading');

var CONTROLLER_NAME = 'users';

module.exports = {
    getRegister: function(req, res, next) {
        res.render(CONTROLLER_NAME + '/register')
    },
    postRegister: function(req, res, next) {
        var newUserData = req.body;
        
        if (!newUserData.username || newUserData.username.length < 6 || newUserData.username.length > 20) {
            req.session.error = 'The username should be between 6 and 20 characters long!';
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

            uploading.createDir('/', user.username);

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
    }
};