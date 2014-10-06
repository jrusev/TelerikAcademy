var connectionString = 'mongodb://localhost/chat-db';

require('./config/mongoose').connect(connectionString, function () {
        // initiliazise the DB models
        require('./models/user').init();
        require('./models/message').init();
        exchangeMessages();
});

function exchangeMessages() {
    var users = require('./controllers/usersController');
    var messages = require('./controllers/messagesController');

    var admins = [    
        { username: 'user1', password: 'pass1' },
        { username: 'user2', password: 'pass2' }
    ];

    var message = {
        from: 'user1',
        to: 'user2',
        text: 'Hello, user2!'
    };

    users.seed(admins, function () {
        messages.clearAll(function () {
            messages.sendMessage(message, function () {
                messages.getMessages({from: 'user1', to: 'user2'}, function (err, messages) {
                    console.log('All messages: \n' + messages);
                });        
            });
        });
    }); 
}
