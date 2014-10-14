### Frequently used commands

* `heroku login` - log in using the email and password of your Heroku account
* `heroku create` - create an app on Heroku (also creates a remote repository)
* `git push heroku master` - pushing commits from your local repository to heroku.
* `foreman start web` - run the app locally (at localhost:5000)
* `heroku open` - open the app in a browser at its URL
* `heroku apps:rename newname` - rename an app at any time (newname.herokuapp.com)
* `heroku keys:add` - adds RSA key
* `heroku git:remote -a HerokuAppName` - adds the heroku remote (when you get 'No app specified')
* `heroku config:set NODE_ENV=production` - set NODE_ENV (it is unset by default!)
* `heroku config:set TIMES=2` - to set the config var on Heroku
* `heroku logs --tail > logs.txt` - view logs about your running app
* `heroku run bash` - opens up a shell on a one-off dyno
* `heroku restart` - restarts the heroku app (on heroku)

[Getting Started with Node.js on Heroku](https://devcenter.heroku.com/articles/getting-started-with-nodejs)
