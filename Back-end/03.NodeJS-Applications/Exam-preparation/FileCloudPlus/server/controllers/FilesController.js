var encryption = require('../utilities/encryption'),
    uploading = require('../utilities/uploading'),
    files = require('../data/files');
var users = require('../data/files');
var moment = require('moment');

var CONTROLLER_NAME = 'files';
var URL_PASSWORD = 'magic unicorns pesho gosho1';

var uploadedFiles = [];

function getDate() {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1;

    var yyyy = today.getFullYear();
    if(dd < 10){
        dd='0'+dd
    }

    if(mm < 10){
        mm= '0'+mm
    }

    return dd + '-' + mm + '-' + yyyy;
}

module.exports = {
    getUpload : function(req, res, next) {
        res.render(CONTROLLER_NAME + '/upload');
    },
    postUpload: function(req, res, next) {
        req.pipe(req.busboy);

        var username = req.user.username;

        req.busboy.on('file', function (fieldname, file, filename) {
            var fileNameHashed = encryption.generateHashedPassword(encryption.generateSalt(), filename);
            var currentDate = getDate();
            var path = '/' + username + '/' + currentDate + '/';
            var url = path + fileNameHashed;
            var urlEncrypted = encryption.encrypt(url, URL_PASSWORD);

            uploading.saveFile(file, path, fileNameHashed);

            uploadedFiles[username] = uploadedFiles[username] || [];

            uploadedFiles[username][fieldname] = uploadedFiles[username][fieldname] || {};
            var dbFile = uploadedFiles[username][fieldname];
            dbFile.url = urlEncrypted;
            dbFile.fileName = filename;
            dbFile.owner = req.user._id;
        });

        req.busboy.on('field', function(fieldname, val) {
            var index = fieldname.split('_')[1];
            uploadedFiles[username] = uploadedFiles[username] || [];
            uploadedFiles[username]['file_' + index] = uploadedFiles[username]['file_' + index] || {};
            var dbFile = uploadedFiles[username]['file_' + index];
            dbFile.isPrivate = !!val;
        });

        req.busboy.on('finish', function() {
            files.addFiles(uploadedFiles[username]);
            res.redirect('/upload-results');
        });
    },
    getResults: function(req, res, next) {
        var resultFiles = uploadedFiles[req.user.username];

        if (!resultFiles) {
            res.redirect('/upload');
        }
        else {
            var files = [];
            for(var file in resultFiles) {
                files.push(resultFiles[file]);
            }

            uploadedFiles[req.user.username] = undefined;

            res.render(CONTROLLER_NAME + '/result', { files: files });
        }
    },
    download: function(req, res, next) {
        var url = req.params.id;
        var decryptedUrl = encryption.decrypt(url, URL_PASSWORD);
        
        files.findOne({url: url}, function(err, file) {
            if (!file) {
                return res.status(400).send({ message: 'File does not exist!'});
            }
            
            if (file.isPrivate) {
                if (!file.owner.equals(req.user._id)) {
                    return res.status(403).send('This is a private file.');
                }
                
                res.download(__dirname + '/../../files' + decryptedUrl, file.fileName);       
               
            }
            else {
                res.download(__dirname + '/../../files' + decryptedUrl, file.fileName);
            }
        });
    },
    getPublicFiles: function (req, res) {
        files.find({'isPrivate': false}, {'uploadingDate' : 'desc'}, function (err, files) {
            res.render(CONTROLLER_NAME + '/public', {files: files, moment: moment});
        });
    },
    getMyFiles: function (req, res) {
        files.find({'owner': req.user._id}, {'uploadingDate' : 'desc'}, function (err, files) {
            res.render(CONTROLLER_NAME + '/myfiles', {files: files, moment: moment});
        });
    },
    delete: function(req, res, next) {
        var url = req.params.id;
        var decryptedUrl = encryption.decrypt(url, URL_PASSWORD);
        
        files.findOne({url: url}, function(err, file) {
            if (!file) {
                return res.status(400).send({ message: 'File does not exist!'});
            }
    
            if (!file.owner.equals(req.user._id)) {
                return res.status(403).send('This is not your file!');
            }

            files.delete(file._id, function (err) {
                if (err) throw err;
                res.send('File deleted');            
            });          
        });
    },
    update: function(req, res, next) {
        var url = req.params.id;
        var decryptedUrl = encryption.decrypt(url, URL_PASSWORD);
        
        files.findOne({url: url}, function(err, file) {
            if (!file) {
                return res.status(400).send({ message: 'File does not exist!'});
            }
    
            if (!file.owner.equals(req.user._id)) {
                return res.status(403).send('This is not your file!');
            }

            files.update(file._id, {isPrivate: !file.isPrivate}, function (err) {
                if (err) throw err;
                res.send('File updated');            
            });          
        });
    },
};