# Ode OS version 0.0.2

Ode OS est un système d'exploitation réalisé avec Cosmos, écrit en C# et réalisé par valentinbreiz !

## Pre-requis pour generer Ode OS

* Visual Studio 2015
* [Cosmos DevKit](https://github.com/CosmosOS/Cosmos/wiki/Devkit) : Un petit tutoriel (en anglais) pour générer Cosmos Devkit
   - Avec ces fichiers [Cosmos Bugfixes branch](https://github.com/jp2masa/Cosmos/tree/Bugfixes) par jp2masa.
* VMWare ou Bochs (machines virtuelles)


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
Etat mis à jour le 01/05/2017

* Lancer des programmes consoles complets.                        :heavy_check_mark:
  - Integration d'un editeur de texte                             :grey_question: **Presque terminé**
  - Amelioration application parametres                           :grey_question: **Presque terminé** 

* Corriger quelques erreurs.                                      :grey_question: **En cours**
* Installation de OdeOS                                           :heavy_check_mark:
  - Installation et désinstallation                               :x:
  - Formatage                                                     :heavy_check_mark:
* Pouvoir supprimer un dossier qui contient des fichiers.         :heavy_check_mark:
* Gestion des utilisateurs avec base de donnée.                   :heavy_check_mark: :grey_question:
* Connexion réseau                                                :x:
* Création d'une interface utilisateur (GUI)
  - Gestion des fenêtres                                          :grey_question:
  - Gestion de la souris                                          :grey_question:
  - Gestion d'un bureau et menus                                  :grey_question:
  - Gestion des programmes fenêtres                               :grey_question:
* Traduction du système par [Kevin](https://github.com/TheCool1James) :grey_question:

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
