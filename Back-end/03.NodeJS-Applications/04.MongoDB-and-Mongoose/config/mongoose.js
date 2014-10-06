var mongoose = require('mongoose');

module.exports.connect = function (dbName) {
    mongoose.connect(dbName);
    var db = mongoose.connection;
    
    // initiliazise the DB models
    require('../models/user').init();
    require('../models/message').init();

    db.once('open', function (err) {
        if (err) {
            console.log('DB ERROR: ' + err);
        }
        
        console.log('MongoDb is running at ' + dbName);
    });

    db.on("error", function (error) {
        console.log(error);
    });
};

