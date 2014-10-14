var express = require('express'),
    bodyParser = require('body-parser'),
    cookieParser = require('cookie-parser'),
    session = require('express-session'),
    passport = require('passport'),
    busboy = require('connect-busboy');
var stylus = require('stylus');
var nib = require('nib');

module.exports = function (app, config) {
    app.set('view engine', 'jade');
    app.set('views', config.rootPath + '/views');
    app.use(stylus.middleware({
        src: config.rootPath + '/views',
        dest: config.rootPath + '/public',
        compile: function (str, path, fn) {
          return stylus(str)
          .set('filename', path)
          .set('compress', true)
          .use(nib());
        }
      }));
    app.use(express.static(config.rootPath + '/public'));
    app.use(busboy({ immediate: false }));
    app.use(bodyParser.json());
    app.use(bodyParser.urlencoded({extended: true}));
    app.use(cookieParser());
    app.use(session({resave: true, saveUninitialized: true, secret: 'magic unicorns ftw'}));
    app.use(passport.initialize());
    app.use(passport.session());
    app.use(function(req, res, next) {
        if (req.session.errorMessage) {
            app.locals.errorMessage = req.session.errorMessage;
        }

        next();
    });
    app.use(function(req, res, next) {
        app.locals.currentUser = req.user;
        next();
    })
};