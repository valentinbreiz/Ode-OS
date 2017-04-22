# Ode OS version 0.0.2

Ode OS est un systeme d'exploitation réalisé avec Cosmos et écrit en C# ! Réalisé par valentinbreiz aidé par [Memphis](https://github.com/MichaelTheShifter/memphis) et l'équipe Cosmos.

## Pre-requis pour generer

* Visual Studio 2015
* [Cosmos DevKit](https://github.com/CosmosOS/Cosmos/wiki/Devkit) : Un petit tutoriel (en anglais) pour générer Cosmos Devkit
   - Avec les fichiers de la PR522 (https://github.com/CosmosOS/Cosmos/pull/522)
* VMWare ou Bochs


## Fonctionnalités
### La version 0.0.2 contient plusieurs fonctionnalités :
* Création suppression modification de dossiers ou fichiers
* Déplacement dans les dossiers
* Commandes mise hors tension ou redemarrer
* Quelques autres commandes utiles à voir ci dessous
* Tests rudimentaires
* Applications pre-installés basiques
* Correction de quelques erreurs.
* Blue Screen of Death quand il y a une erreur systeme.

### À venir dans la version 0.0.3 et autres :
* Lancer des programmes consoles complets.                        :white_check_mark:
  - Integration d'un editeur de texte                             Presque terminé
  - Amelioration application parametres                           Presque terminé

* Corriger quelques erreurs.
* Installation de OdeOS                                           :white_check_mark:
  - Installation et désinstallation                               :white_check_mark:
  - Formatage                                                     :white_check_mark:
* Pouvoir supprimer un dossier qui contient des fichiers.         :white_check_mark:
* Gestion des utilisateurs avec base de donnée.                   :white_check_mark:
* Connexion réseau
* Création d'une interface utilisateur (GUI)
  - Gestion des fenêtres                                          :white_check_mark:
  - Gestion de la souris
  - Gestion d'un bureau et menus
  - Gestion des programmes fenêtres
* Traduction du système par [Kevin](https://github.com/TheCool1James)

## Commandes

### Commandes systemes :

Permet de redemarrer Ode OS :
```
reboot
```
Permet d'éteindre Ode OS :
```
shutdown
```
Permet de creer un dossier :
```
dir -c nomdudossier
```
Permet de supprimer un dossier :
```
dir -r nomdudossier
```
Permet d'afficher le contenu d'un fichier :
```
fil -p nomdufichier
```
Permet de créer un fichier :
```
fil -c nomdufichier
```
Permet de supprimer un fichier :
```
fil -r nomdufichier
```
Permet de se déplacer dans les dossiers :
```
cd dossiercible
```
ou pour retour
```
cd ..
```
Verouiller Ode OS
```
lock
```
Lancer un programme
```
prgm -s Nomduprogramme
```
Lister les programmes
```
prgm -s Nomduprogramme
```
### Commandes utiles :

Permet d'afficher les volumes disponibles :
```
vol -l
```
Permet d'afficher les fichier et dossiers :
```
dir -l
```
Permet de nettoyer la console :
```
clear
```
Permet d'obtenir de l'aide :
```
help
```
Permet d'obtenir quelques informations :
```
infos
```

### Commandes tests :
Permet de réaliser un crash test du systeme
```
test_crash
```
Permet d'afficher une fenêtre (pour l'instant pas de retour, juste affiché)
```
test_window
```
