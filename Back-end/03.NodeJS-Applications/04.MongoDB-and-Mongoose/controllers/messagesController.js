var mongoose = require('mongoose');
var User = mongoose.model('User');
var Message = mongoose.model('Message');

module.exports.sendMessage = function (msgData, callback) {
    User.findOne({username: msgData.from}, function (error, sender) {
        if (error) return console.log(error);

        User.findOne({username: msgData.to}, function (error, receiver) {
            if (error) return console.log(error);

            var newMessage = new Message({
                from: sender,
                to: receiver,
                text: msgData.text
            });

            newMessage.save(function (error, message) {                        
                if (error) return console.log(error);

                console.log(sender.username + ' said to ' + receiver.username + ' : ' + message.text);
                callback();                       
            });
        })       
    })
};

module.exports.getMessages = function (queryData, callback) {
    User.findOne({username: queryData.from}, function (error, sender) {
        if (error) return console.log(error);

        User.findOne({username: queryData.to}, function (error, receiver) {                
            if (error) return console.log(error);

            Message.find()
                .where('from').equals(sender._id)
                .where('to').equals(receiver._id)
                .exec(callback);                
        })
        
    })
};

module.exports.clearAll = function(callback) {
    Message.remove({}, function (error) {
        if (error) return console.log(error);

        console.log('Old messages cleared from database...')
        if (typeof(callback) === "function") {
            callback();
        }
    });   
}