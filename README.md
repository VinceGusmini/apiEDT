# API_EDT


## [IUT Paris Descartes](http://www.iut.parisdescartes.fr/)


## Présentation

Dans le cadre du module M5 nous avons dû concevoir le bureau virtuel d'un responsable d’Emploi Du Temps (EDT).
Pour réaliser ses emplois du temps, un responsable d'EDT obtient des informations de l'établissement sous forme de listes et est en relation avec des responsables des matières.

Cette API a pour but de gérer la donnée nécessaire au bon fonctionnement de l'application web.

### À noter : Le projet a été séparé en 2 parties: BackEnd et FrontEnd. Ce repo est celui du BackEnd. Pour le FrontEnd voir [ici](https://github.com/mvestrotech/schedules)


### Technologie utilisée :

- Asp.net core 2.2
- EntityFrameworkCore
- Server : MySQL

### Features:

- API REST
- CRUD supported

### Installation

Je recommande l'exécution de l'API sur [Visual Studio Code](https://code.visualstudio.com/download)

- Veuillez installer : [SDK .Net Core 2.2](https://dotnet.microsoft.com/download/dotnet-core/2.2) et [L'extension C# pour VS Code](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp) (Elle est disponible dans la section "Extensions", sur le menu de gauche, directement dans VS Code).

- Veuillez vérifier si vous possédez [Git](https://git-scm.com/).

1) Placez vous dans un dossier.

2) Lancer une invite de commandes et exécuter la commande suivante :
```
git clone https://github.com/VinceGusmini/apiEDT
```
3) Ouvrez le dossier du projet avec VS Code.

4) Démarrez votre server MySQL et notez son url d'accès ainsi que ses modalités de connexion.

5) Importez notre base de données sur votre server MySQL. Le fichier se trouve dans le dossier : Back --> BDD_SQL --> proj.sql

6) Sur VS Code : modifier le fichier appsettings.json afin d'y mettre vos modalités de connexion à MySQL.
```
"apiEDTDatabase": "server=[VotreAdresseMySQL];userid=[VotreUserId];password=[VotrePassword];database=proj;"
```
7) Il est possible que des erreurs soit détectés par VS Code, si c'est le cas fermez et réouvrez VS Code, sinon vous pouvez exécuté l'API (CTRL+F5).

8) Pour tester le bon fonctionnement de l'API vous pouvez utilisé [ARC : Advanced REST Client](https://install.advancedrestclient.com/install).

*Exemple de lien pour tester le bon fonctionnement de l'API : [https://localhost:5001/api/matiere](https://localhost:5001/api/matiere), permet de récupérer la liste des matières*

En cas d'erreur avec EntityFrameworkCore vérifiez que vous disposez du package :
```
dotnet add package Microsoft.EntityFrameworkCore
```

## Versioning

J'ai utilisé Git pour le versionning de ce projet.

## Author

* [Vincent Gusmini](https://github.com/VinceGusmini)
* Pour le front [Nicolas Garnier](https://github.com/mvestrotech)

#### Remerciements
Merci à [Ayaz ABDUL CADER](https://github.com/AyazBulls) pour la structure du ReadMe.