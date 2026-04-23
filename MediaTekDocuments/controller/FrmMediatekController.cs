using System.Collections.Generic;
using MediaTekDocuments.model;
using MediaTekDocuments.dal;

namespace MediaTekDocuments.controller
{
    /// <summary>
    /// Contrôleur lié à FrmMediatek
    /// </summary>
    class FrmMediatekController
    {
        private readonly Access access;

        public FrmMediatekController()
        {
            access = Access.GetInstance();
        }

        public List<Categorie> GetAllGenres() { return access.GetAllGenres(); }
        public List<Livre> GetAllLivres() { return access.GetAllLivres(); }
        public List<Dvd> GetAllDvd() { return access.GetAllDvd(); }
        public List<Revue> GetAllRevues() { return access.GetAllRevues(); }
        public List<Categorie> GetAllRayons() { return access.GetAllRayons(); }
        public List<Categorie> GetAllPublics() { return access.GetAllPublics(); }
        public List<Exemplaire> GetExemplairesRevue(string idDocument) { return access.GetExemplairesRevue(idDocument); }
        public bool CreerExemplaire(Exemplaire exemplaire) { return access.CreerExemplaire(exemplaire); }
        public List<Suivi> GetAllSuivis() { return access.GetAllSuivis(); }
        public List<CommandeDocument> GetCommandesDocument(string idLivreDvd) { return access.GetCommandesDocument(idLivreDvd); }
        public bool CreerCommandeDocument(CommandeDocument commande) { return access.CreerCommandeDocument(commande); }
        public bool ModifierSuiviCommande(CommandeDocument commande) { return access.ModifierSuiviCommande(commande); }
        public bool SupprimerCommandeDocument(string id) { return access.SupprimerCommandeDocument(id); }
        public List<CommandeRevue> GetCommandesRevue(string idRevue) { return access.GetCommandesRevue(idRevue); }
        public bool CreerCommandeRevue(CommandeRevue commande) { return access.CreerCommandeRevue(commande); }
        public bool SupprimerCommandeRevue(string id) { return access.SupprimerCommandeRevue(id); }
        public List<CommandeRevue> GetAbonnementsExpiresBientot() { return access.GetAbonnementsExpiresBientot(); }
        public Utilisateur GetUtilisateur(string login, string pwd) { return access.GetUtilisateur(login, pwd); }
    }
}