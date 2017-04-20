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
  - Integration d'une application test.
* Correction de quelques erreurs.
* Blue Screen of Death quand il y a une erreur systeme.

### À venir dans la version 0.0.3 et autres :
* Lancer des programmes consoles complets.
  - Integration de [MIV](https://github.com/bartashevich/MIV) (editeur de texte)

* Corriger quelques erreurs.
* Installation de OdeOS
  - Installation et désinstallation
  - Formatage
* Pouvoir supprimer un dossier qui contient des fichiers.
* Gestion des utilisateurs avec base de donnée
* Connexion réseau
* Création d'une interface utilisateur (GUI)
  - Gestion des fenêtres
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
Permet de réaliser un crash test du systeme (ne fonctionne pas pour l'instant)
```
test_crash
```
