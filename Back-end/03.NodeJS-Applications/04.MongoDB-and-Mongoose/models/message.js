var mongoose = require('mongoose');

module.exports.init = function () {
    var messageSchema = new mongoose.Schema({
        from : {
            type: mongoose.Schema.Types.ObjectId,
            ref: 'User'
        },
        to : {
            type: mongoose.Schema.Types.ObjectId,
            ref: 'User'
        },
        text: {
            type: String
        }
    });

    var Message = mongoose.model('Message', messageSchema);
    console.log('Message model created...');
};
