MediatekDocuments

Ce dépôt est une évolution du projet d'origine disponible ici :
https://github.com/CNED-SLAM/MediaTekDocuments
Le README de ce dépôt présente la présentation complète de l'application d'origine.

MediatekDocuments est une application desktop C# permettant de gérer les documents (livres, DVD, revues) d'un réseau de médiathèques (MediaTek86). Elle consomme une API REST PHP pour accéder à la base de données MySQL.

Fonctionnalités ajoutées
Authentification avec gestion des droits
L'application dispose d'une fenêtre de connexion sécurisée. Selon le service de l'utilisateur connecté, l'accès aux fonctionnalités est restreint :

Service Administratif : accès complet à tous les onglets
Service Prêts : onglets Commandes livres/DVD et Commandes revues grisés (non accessibles)
Service Culture : accès refusé, l'application se ferme après un message d'information

Comptes de test :
LoginMot de passeServiceadminadminpwdAdministratif (accès complet)pretspretspwdPrêts (commandes inaccessibles)cultureculturepwdCulture (accès refusé)
Alerte abonnements expirant bientôt
À la connexion avec un compte Administratif, une fenêtre d'alerte s'affiche automatiquement si des abonnements de revues arrivent à expiration dans les 30 prochains jours.
Gestion des commandes de livres et DVD
Un nouvel onglet "Commandes livres/DVD" permet de rechercher les commandes d'un livre ou DVD par son numéro, et d'ajouter, modifier le suivi ou supprimer des commandes.
Gestion des abonnements de revues
Un nouvel onglet "Commandes revues" permet de gérer les abonnements d'une revue : recherche par numéro, ajout et suppression d'abonnements.
Journalisation avec NLog
Les erreurs et événements importants sont enregistrés dans des fichiers de log via la bibliothèque NLog.
Tests unitaires
Des tests unitaires ont été ajoutés pour valider les principales fonctionnalités de l'application.
Documentation technique
La documentation technique du code C# a été générée avec Sandcastle Help File Builder (SHFB) et est accessible en ligne :
https://orianecned.alwaysdata.net/doc_mediatekdocuments/index.html

Captures d'écran
Fenêtre de connexion
(insérer capture connexion)
Interface principale — Onglet Livres
(insérer capture onglet livres)
Onglet DVD
(insérer capture onglet dvd)
Onglet Revues
(insérer capture onglet revues)
Onglet Parutions des revues
(insérer capture onglet parutions)
Onglet Commandes livres/DVD
(insérer capture onglet commandes livres)
Onglet Commandes revues
(insérer capture onglet commandes revues)

Mode opératoire — Installation et utilisation en local
Prérequis

Visual Studio 2022 (ou version ultérieure)
Extension Newtonsoft.Json (NuGet)
Extension NLog (NuGet)
L'API REST MediatekDocuments installée et fonctionnelle (voir dépôt rest_mediatekdocuments)

Installation
1. Cloner le dépôt
git clone https://github.com/orient75015/mediatekdocuments.git
Renommer le dossier en mediatekdocuments (enlever _master si nécessaire).
2. Ouvrir le projet dans Visual Studio
Double-cliquer sur le fichier MediaTekDocuments.sln.
3. Restaurer les packages NuGet
Dans Visual Studio : Outils → Gestionnaire de package NuGet → Restaurer les packages NuGet.
4. Configurer App.config
Ouvrir le fichier App.config et renseigner l'URL de l'API et les identifiants :
xml<add key="uriApi" value="http://localhost/rest_mediatekdocuments/"/>
<add key="apiCredentials" value="admin:adminpwd"/>
5. Lancer l'application
Appuyer sur F5 dans Visual Studio ou cliquer sur le bouton "Démarrer".
6. Se connecter
Utiliser l'un des comptes de test indiqués dans le tableau ci-dessus.

Installation via l'installeur
Un installeur MSI est disponible dans le dossier installeur/ du dépôt. Il permet d'installer l'application directement sur un poste Windows sans nécessiter Visual Studio. L'application installée se connecte à l'API distante hébergée sur Alwaysdata.
URL de l'API distante : https://orianecned.alwaysdata.net/api/
