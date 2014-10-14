var files = require('../data/files');
var users = require('../data/users');

function getStats(req, res, next) {
    files.count(function (err, totalFiles) {
        if (err) throw err;        
        users.count(function (err, totalUsers) {
            if (err) throw err;            
            res.render('index', {                
                totalFiles: totalFiles,
                totalUsers: totalUsers                          
            });            
        });
    });
} 

module.exports = {
    getStats: getStats   
}