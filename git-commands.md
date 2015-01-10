### Create SSH key

1. Go to your user folder (`%USERPROFILE%`) and backup your existing .ssh folder, if one exists
2. `ssh-keygen -t rsa -C "your.email@gmail.com"`
3. Enter passphrase -> just press Enter, unless you wanto to enter your password every time
4. Open the `id_ras.pub` inside .ssh folder (you can use notepad) and copy the SSH key (copy the entire line)
5. Go to github->account settings->SSH Keys->Add SSH key
6. Give it a tile, e.g. "my-PC" or "my-home-laptop", and paste the SSH key, select "Add key"
7. `ssh -T git@github.com` - Are you sure you want to continue connecting? -> Yes

### Get a Git project

You can get a Git project using two main approaches:

1. Transform the current directory into a Git repository:
 * `git init`
 * To add a new remote (get the SSH link not the HTTP from github): 
   * `git remote add origin git@github.com:user/repo.git`
2. If you want to get a copy of an existing Git repository:
 * `git clone git@github.com:user/repo.git`

### Frequently used commands

* `git pull origin master` - imports commits from a remote repository (e.g. on GitHub) into your local repo.
* `git add -A .` - adds all changes (new, changed or removed files) in the working directory to the staging area
* `git commit -m "put your comment here"` - commits the staged snapshot to the local repository
* `git push origin master` - pushing commits from your local repository to a remote repo.
* `git status -s` - displays the state of the working directory and the staging area
* `git log --oneline` - shows the commit logs
* `Shift+ Z,Z` -> exit to the command prompt (e.g. after a long git status message)
* `git mv oldname temp` + `git mv temp newname` - renames file (helpful when changing capitalization of filenames)
* `git remote -v` - gets a list of any configured remote urls
* `git remote set-url origin git@github.com:user/newrepo.git` - change the URL for a remote Git repository

### Branching

* `git branch <newbranch>` - creates a new branch.
* `git checkout -b <new-branch>` - create and check out new-branch (runs git branch before running git checkout).
* `git branch` - lists all branches.
* `git checkout <newbranch>` - switch to the new branch.
* `git merge <otherbranch>` - merge the specified branch into the current branch.
* `git branch -d <localBranch>` - delete a local branch.
* `git push origin --delete <branchName>` - delete a remote branch.
* `git checkout -b <new-feature> origin/<new-feature>` - to work on a <new-feature> branch after cloning

### Undo changes (use with care!)

* `git checkout [revision]` - goes back to an old revision (commit) in a temporary branch and does not change history
* `git checkout master` - returns back to the master branch.
* `git revert [revision]` - go back to an old version and create a new commit (use when work is already shared).
* `git reset --hard [revision]` - goes back to an old revision and deletes history (use only when work is not already shared).
* Revert to a previous Git commit - [http://stackoverflow.com/questions/4114095/revert-to-a-previous-git-commit]
* `git checkout -- .` - discard unstaged changes (changes in the working copy that are not added to the index).



