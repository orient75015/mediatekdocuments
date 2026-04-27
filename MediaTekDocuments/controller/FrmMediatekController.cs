using System.Collections.Generic;
using MediaTekDocuments.model;
using MediaTekDocuments.dal;

namespace MediaTekDocuments.controller
{
    /// <summary>
    /// Contrôleur lié à FrmMediatek
    /// </summary>
    public class FrmMediatekController
    {
        private readonly Access access;

        public FrmMediatekController()
        {
            access = Access.GetInstance();
        }

        /// <summary>Retourne la liste de tous les genres</summary>
        public List<Categorie> GetAllGenres() { return access.GetAllGenres(); }
        /// <summary>Retourne la liste de tous les livres</summary>
        public List<Livre> GetAllLivres() { return access.GetAllLivres(); }
        /// <summary>Retourne la liste de tous les dvd</summary>
        public List<Dvd> GetAllDvd() { return access.GetAllDvd(); }
        /// <summary>Retourne la liste de toutes les revues</summary>
        public List<Revue> GetAllRevues() { return access.GetAllRevues(); }
        /// <summary>Retourne la liste de tous les rayons</summary>
        public List<Categorie> GetAllRayons() { return access.GetAllRayons(); }
        /// <summary>Retourne la liste de tous les publics</summary>
        public List<Categorie> GetAllPublics() { return access.GetAllPublics(); }
        /// <summary>Retourne la liste des exemplaires d'une revue</summary>
        public List<Exemplaire> GetExemplairesRevue(string idDocument) { return access.GetExemplairesRevue(idDocument); }
        /// <summary>Crée un exemplaire</summary>
        public bool CreerExemplaire(Exemplaire exemplaire) { return access.CreerExemplaire(exemplaire); }
        /// <summary>Retourne la liste de tous les suivis</summary>
        public List<Suivi> GetAllSuivis() { return access.GetAllSuivis(); }
        /// <summary>Retourne la liste des commandes d'un livre ou dvd</summary>
        public List<CommandeDocument> GetCommandesDocument(string idLivreDvd) { return access.GetCommandesDocument(idLivreDvd); }
        /// <summary>Crée une commande de livre ou dvd</summary>
        public bool CreerCommandeDocument(CommandeDocument commande) { return access.CreerCommandeDocument(commande); }
        /// <summary>Modifie le suivi d'une commande de livre ou dvd</summary>
        public bool ModifierSuiviCommande(CommandeDocument commande) { return access.ModifierSuiviCommande(commande); }
        /// <summary>Supprime une commande de livre ou dvd</summary>
        public bool SupprimerCommandeDocument(string id) { return access.SupprimerCommandeDocument(id); }
        /// <summary>Retourne la liste des commandes d'une revue</summary>
        public List<CommandeRevue> GetCommandesRevue(string idRevue) { return access.GetCommandesRevue(idRevue); }
        /// <summary>Crée une commande de revue (abonnement)</summary>
        public bool CreerCommandeRevue(CommandeRevue commande) { return access.CreerCommandeRevue(commande); }
        /// <summary>Supprime une commande de revue</summary>
        public bool SupprimerCommandeRevue(string id) { return access.SupprimerCommandeRevue(id); }
        /// <summary>Retourne les abonnements qui expirent bientôt</summary>
        public List<CommandeRevue> GetAbonnementsExpiresBientot() { return access.GetAbonnementsExpiresBientot(); }
        /// <summary>Retourne l'utilisateur correspondant au login/pwd</summary>
        public Utilisateur GetUtilisateur(string login, string pwd) { return access.GetUtilisateur(login, pwd); }
    }
}