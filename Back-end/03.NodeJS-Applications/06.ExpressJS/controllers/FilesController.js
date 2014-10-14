var encryption = require('../utilities/encryption');
var fs = require('fs');
var inspect = require('util').inspect;
var moment = require('moment');

var User = require('mongoose').model('User');
var File = require('mongoose').model('File');

var controllerName = 'files';
var encryptionPass = 'ta-file-upload-magic-unicorns-cats';

function getCurrentDate() {
    var date = new Date();
    var dateString = (date.getMonth() + 1) + "_" + date.getDate() + "_" + date.getFullYear().toString().substr(2,2);
    return dateString;
}

module.exports = {    
    getPublicFiles: function (req, res) {
        File.find({private: false})
        .populate('owner', 'username')
        .exec(function (err, files) {
            res.render(controllerName + '/public', {files: files, moment: moment});
        });        
    },
    getMyFiles: function (req, res) {
        File.find({'owner': req.user._id}, function (err, files) {
            res.render(controllerName + '/myfiles', {files: files, moment: moment});
        });
    },
    getUpload: function(req, res, next) {
        res.render(controllerName + '/upload');
    },
    postUpload: function(req, res, next) {

        var files = {};

        req.busboy.on('file', function (fieldname, file, filename) {
            
            var url = req.user.username + '/' + getCurrentDate() + '/' + filename;
            var cipheredUrl = encryption.encrypt(url, encryptionPass);
            files[fieldname] = files[fieldname] || {};
            files[fieldname].filename = filename;
            files[fieldname].url = cipheredUrl;
            files[fieldname].owner = req.user._id;
            
            var path = __dirname + '/../file_uploads/' + url;

            var userNamePath = __dirname + '/../file_uploads/' + req.user.username;
            var datePath = userNamePath + '/' + getCurrentDate();

            if (fs.existsSync(path)) {
                fs.unlinkSync(path);
            }

            fs.mkdir(userNamePath, 0777, function(err) {
                if (err && err.code != 'EEXIST') console.log(err);
                else {
                    fs.mkdir(datePath, 0777, function(err) {
                        if (err && err.code != 'EEXIST') console.log(err);
                        else {
                            var fstream = fs.createWriteStream(path);
                            file.pipe(fstream);
                        }
                    });
                }
            });
        });
        
        req.busboy.on('field', function(fieldname, val) {
            var file = fieldname.substr(0, fieldname.indexOf('private'));
            files[file] = files[file] || {};
            files[file].private = val;
            console.log(files[file] + ' is ' + val);
        });

        req.busboy.on('finish', function() {
            var count = 0;            
            for (var fieldname in files) {
               var file = files[fieldname];
                console.log(file);
                new File({
                    filename: file.filename,
                    url: file.url,
                    private: file.private ? true : false,
                    owner: file.owner,
                    uploadDate: new Date()
                })
                .save(function() {
                    count++;
                    if (count == Object.keys(files).length) {
                        console.log('Files saved to db...');
                        res.redirect('/myfiles');
                    }
                });
            }
        });
        
        req.pipe(req.busboy);
    },
    download: function(req, res, next) {
        var cipher = req.params.id;
        var path = encryption.decrypt(cipher, encryptionPass);

        var parts = path.split('/');
        File.find({url: path}).exec(function(err, file) {
            if (file.private) {
                User.find({username: parts[0]}).exec(function(err, user) {
                    if (req.user.username == user.username) {
                        res.download(__dirname + '/../file_uploads/' + path);
                    }
                });
            }
            else {
                res.download(__dirname + '/../file_uploads/' + path);
            }
        });
    }
};