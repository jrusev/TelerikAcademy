var auth = require('./auth'),
    controllers = require('../controllers');

module.exports = function(app) {
    // User
    app.get('/register', controllers.users.getRegister);
    app.post('/register', controllers.users.postRegister);
    app.get('/login', controllers.users.getLogin);
    app.get('/profile', auth.isAuthenticated, controllers.users.getProfile);
    app.post('/profile', auth.isAuthenticated, controllers.users.postProfile);
    
    // Auth
    app.post('/login', auth.login);
    app.get('/logout', auth.isAuthenticated, auth.logout);

    // Events
    app.get('/events/:id', auth.isAuthenticated, controllers.events.getDetail);
    app.post('/events/join/:id', auth.isAuthenticated, controllers.events.join);
    app.post('/events/leave/:id', auth.isAuthenticated, controllers.events.leave);
    app.get('/create', auth.isAuthenticated, controllers.events.getCreate);
    app.post('/create', auth.isAuthenticated, controllers.events.postCreate);
    app.get('/active-events', auth.isAuthenticated, controllers.events.getActive);
    app.get('/passed-events', auth.isAuthenticated, controllers.events.getPassed);

    app.get('/', controllers.stats.getStats);

    app.get('*', function(req, res) {
        res.render('index');
    });
};