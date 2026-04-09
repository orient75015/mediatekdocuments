using System;

namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier CommandeDocument (commande d'un livre ou DVD)
    /// </summary>
    public class CommandeDocument
    {
        public string Id { get; set; }
        public DateTime DateCommande { get; set; }
        public double Montant { get; set; }
        public int NbExemplaire { get; set; }
        public string IdLivreDvd { get; set; }
        public string IdSuivi { get; set; }
        public string Suivi { get; set; }

        public CommandeDocument(string id, DateTime dateCommande, double montant,
            int nbExemplaire, string idLivreDvd, string idSuivi, string suivi)
        {
            this.Id = id;
            this.DateCommande = dateCommande;
            this.Montant = montant;
            this.NbExemplaire = nbExemplaire;
            this.IdLivreDvd = idLivreDvd;
            this.IdSuivi = idSuivi;
            this.Suivi = suivi;
        }
    }
}