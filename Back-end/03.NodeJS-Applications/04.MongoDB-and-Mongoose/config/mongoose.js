var mongoose = require('mongoose');

module.exports.connect = function (connectionString, callback) {
    mongoose.connect(connectionString);
    var db = mongoose.connection;
    
    db.on('error', console.error.bind(console, 'connection error:'));
    db.once('open', function () {
        console.log('Connected successfully to ' + connectionString);
        
        if (typeof(callback) === "function") {
            callback();
        }
    });
};
