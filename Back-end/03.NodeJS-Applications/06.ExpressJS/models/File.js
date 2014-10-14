var mongoose = require('mongoose');

module.exports.init = function() {
    var fileSchema = mongoose.Schema({
        filename: String,
        url: String,
        private: Boolean,
        uploadDate: Date,
        owner : {
            type: mongoose.Schema.Types.ObjectId,
            ref: 'User'
        }
    });

    var File = mongoose.model('File', fileSchema);
};