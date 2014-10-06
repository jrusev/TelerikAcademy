var db = require('./config/mongoose');
var dbName = 'mongodb://localhost/chat-db';

db.connect(dbName);

var usersController = require('./controllers/usersController');
var messagesController = require('./controllers/messagesController');

var users = [    
    {
        username: 'user1',
        password: 'pass1'
    },
    {
        username: 'user2',
        password: 'pass2'
    }
];

usersController.seed(users, function () {
    messagesController.clearAll(function () {
        messagesController.sendMessage({
            from: 'user1',
            to: 'user2',
            text: 'Hello, user2!'
        }, function () {
                messagesController.getMessages({
                sender: 'user1',
                receiver: 'user2'
            });        
        });
    });
});
