var auth = require('./auth'),
    controllers = require('../controllers');

module.exports = function(app) {
    // User
    app.get('/register', controllers.users.getRegister);
    app.post('/register', controllers.users.postRegister);
    app.get('/login', controllers.users.getLogin);
    
    // Auth
    app.post('/login', auth.login);
    app.get('/logout', auth.isAuthenticated, auth.logout);

    // Files
    app.get('/upload', auth.isAuthenticated, controllers.files.getUpload);
    app.post('/upload', auth.isAuthenticated, controllers.files.postUpload);
    app.get('/upload-results', auth.isAuthenticated, controllers.files.getResults);
    app.get('/files/download/:id', controllers.files.download);
    app.delete('/files/delete/:id', auth.isAuthenticated, controllers.files.delete);
    app.post('/files/update/:id', auth.isAuthenticated, controllers.files.update);
    app.get('/public', controllers.files.getPublicFiles);
    app.get('/myfiles', auth.isAuthenticated, controllers.files.getMyFiles);

    app.get('/', controllers.stats.getStats);

    app.get('*', function(req, res) {
        res.render('index');
    });
};