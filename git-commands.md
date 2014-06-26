### Create SSH key

1. Go to your user folder (`%USERPROFILE%`) and backup your existing .ssh folder, if one exists
2. `$ ssh-keygen -t rsa -C "your.email@gmail.com"`
3. Enter passphrase -> just press Enter, unless you wanto to enter your password every time
4. Open the `id_ras.pub` inside .ssh folder (you can use notepad) and copy the SSH key (copy the entire line)
5. Go to github->account settings->SSH Keys->Add SSH key
6. Give it a tile, e.g. "my-PC" or "my-home-laptop", and paste the SSH key, select "Add key"
7. `$ ssh -T git@github.com` - Are you sure you want to continue connecting? -> Yes

### Get a Git project

You can get a Git project using two main approaches:

1. Transform the current directory into a Git repository:
 * `$ git init`
 * To add a new remote (get the SSH link not the HTTP from github): 
   * `$ git remote add origin git@github.com:user/repo.git`
2. If you want to get a copy of an existing Git repository:
 * `$ git clone git@github.com:user/repo.git`

### Frequently used commands

* `$ git pull origin master` - imports commits from a remote repository (e.g. on GitHub) into your local repo.
* `$ git add -A .` - adds all changes (new, changed or removed files) in the working directory to the staging area
* `$ git commit -m "put your comment here"` - commits the staged snapshot to the local repository
* `$ git push origin master` - pushing commits from your local repository to a remote repo.

* `$ git status -s` - displays the state of the working directory and the staging area
* `$ git log --oneline` - shows the commit logs

* Shift+ Z,Z -> exit to the command prompt (e.g. after a long git status message)
