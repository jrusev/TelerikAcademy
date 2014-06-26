### Create SSH key

1. got to your user folder (backup your existing .ssh folder, if any) - you can go to %USERPROFILE%
2. `$ ssh-keygen -t rsa -C "your.email@gmail.com"`
3. Enter passphrase: press Enter
4. Open the id_ras.pub inside .ssh folder (you can use notepad) and copy the SSH key (copy the entire line)
5. go to github->account settings->SSH Keys->Add SSH key
6. give it a tile, e.g. "my-PC" or "my-home-laptop", and paste the SSH key, select "Add key"
7. `$ ssh -T git@github.com`

### Get a Git project

You can get a Git project using two main approaches:

1. Transform the current directory into a Git repository (this is usually the first command you’ll run in a new project.).
`$ git init`
To add a new remote (get the SSH link not the HTTP from github): 
`$ git remote add origin git@github.com:user/repo.git`

2. If you want to get a copy of an existing Git repository:
`$ git clone git@github.com:user/repo.git`

### Frequently used commands

`$ git pull origin master` // изтегля каквото ново има от отдалеченото хранилище (GitHub), съкратното му име е "origin"
`$ git add -A .` // слага всичко от работната ти директория в буфера (т.нар. staging area)
`$ git commit -m "put your comment here" // качва каквото има в буфер в локалното ти хранинлище
`$ git push origin master` // качва всичко от локалното хранинлище (master) в отдалеченото (origin)

`$ git status -s` // не е задължително - дава ти дали всичко от работната директория е сложено в буфера
`$ git log --oneline` // не е задължително - дава ти историята на логовете, трябва да си виждаш твоите (значи са на сървъра)

Shift+ Z,Z -> ако екрана е блокирал, като изписва дълъг списък (примерно след git status), го отблокира и показва промпта