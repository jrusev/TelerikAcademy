var File = require('mongoose').model('File');

module.exports = {
    addFiles: function(files) {
        for(var file in files) {
            File.create(files[file]);
        }
    },
    find: function(criteria, sortBy, callback) {        
        File.find(criteria)
            .populate('owner', 'username')
            .sort(sortBy)
            .exec(callback); 
    },
    findOne: function(criteria, callback) {        
        File.findOne(criteria)
            .exec(callback); 
    },
    update: function(fileId, update, callback) {  
        File.findOneAndUpdate({ _id: fileId }, update, callback);
    },
    delete: function(fileId, callback) {  
        File.remove({ _id: fileId }, callback);
    },
    count: function(callback) {
        File.count({}, callback);
    }
};