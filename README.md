#GitPocket
##An Unofficial GitHub App for Windows Phone 8.1

Feel free to participate, comment, report bug or ask for new functionalities.

### Primary Developers

[AlbertoMonteiro](https://github.com/AlbertoMonteiro)

[NPadrutt](https://github.com/NPadrutt)

[RandomlyKnighted](https://github.com/RandomlyKnighted)


### Contributing

(1)You need create a fork, (2)then clone your fork.

(3)Add another remote address of main repository in your local fork using this command:

    git remote add main git@github.com:GitPocket/GitPocket.git

(4)Now you must fetch the main repository:

    git fetch main

(5)Create a local branch that will be syncronized with remote main:

    git checkout -b main-master main/master
    
(6)Go back to your master branch:

    git checkout master
    
(7)Code and then commit!!!

(8)Sync your main-master repository

    git checkout main-master
    git pull --rebase main-master master
    
(9)Then rebase your branch:    
    
    git checkout master
    git rebase main-master

(10)Now push your commits to your remote fork

    git push origin master
    
(11)And now in GitHub site, make your pull-request!
