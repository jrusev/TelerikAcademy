var mongoose = require('mongoose');
var User = mongoose.model('User');
var Message = mongoose.model('Message');

// Send new message
module.exports.sendMessage = function (msgData, callback) {
    User.findOne({username: msgData.from}, function (error, sender) {
        if (error) {
            console.log('Sender not found: ' + error);
        } else {
            User.findOne({username: msgData.to}, function (error, receiver) {
                if (error) {
                    console.log('Receiver not found: ' + error);
                } else {
                    var newMessage = new Message({
                        from: sender,
                        to: receiver,
                        text: msgData.text
                    });

                    newMessage.save(function (error, message) {
                        if (error) {
                            console.log('Save new message error: ' + error);
                        } else {
                            console.log(sender.username + ' said to ' + receiver.username + ' : ' + message.text);
                            callback();
                        }
                    });
                }
            })
        }
    })
};

// Get all messages
module.exports.getMessages = function (queryData) {
    User.findOne({username: queryData.sender}, function (error, sender) {
        if (error) {
            console.log('FIND MESSAGE BY SENDER ERROR: ' + error);
        } else {
            User.findOne({username: queryData.receiver}, function (error, receiver) {
                if (error) {
                    console.log('FIND MESSAGE BY RECEIVER ERROR: ' + error);
                } else {
                    Message.find({})
                           .where('from').equals(sender._id)
                           .where('to').equals(receiver._id)
                           .exec(function (error, messages) {
                               if (error) {
                                   console.log('GET MESSAGE ERROR: ' + error);
                               } else {
                                   console.log('All messages: \n' + messages);
                               }
                           })
                }
            })
        }
    })
};

module.exports.clearAll = function(callback) {
    Message.remove({}, function (err) {
        if (err) return handleError(err);
        // removed!
        console.log('Old messages cleared from database...')
        callback();
    });   
}