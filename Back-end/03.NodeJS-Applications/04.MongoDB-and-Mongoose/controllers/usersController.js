var User = require('mongoose').model('User');

module.exports.registerUser = function (userData) {
    var newUser = new User({
        username: userData.username,
        password: userData.password
    });

    newUser.save(function (error, user) {
        if (error) return console.log(error);

        console.log('New user registered: ' + user);        
    })
};


module.exports.seed = function (users, callback) {
    User.count({}, function (error, count) {
        if (error) return console.log(error);
        
        if (!count) {
            User.create(users);            
        }
        
        if (typeof(callback) === "function") {
            callback();
        }
    });
}
