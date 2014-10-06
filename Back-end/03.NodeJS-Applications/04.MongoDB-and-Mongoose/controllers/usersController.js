var User = require('mongoose').model('User');

// Register new user
module.exports.registerUser = function (userData) {
    var newUser = new User({
        username: userData.username,
        password: userData.password
    });

    newUser.save(function (error, user) {
        if (error) {
            console.log('REGISTER NEW USER ERROR: ' + error);
        } else {
            console.log('New user registered: ' + user);
        }
    })
};


module.exports.seed = function (users, callback) {
    User.count({}, function (err, count) {
        if (err) throw new Error();
        if (!count) {
            User.create(users);
            
        }
        callback();
    });
}
