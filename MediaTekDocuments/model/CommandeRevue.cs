using System;

namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier CommandeRevue (abonnement ou renouvellement d'une revue)
    /// </summary>
    public class CommandeRevue
    {
        public string Id { get; set; }
        public DateTime DateCommande { get; set; }
        public double Montant { get; set; }
        public DateTime DateFinAbonnement { get; set; }
        public string IdRevue { get; set; }
        public string Titre { get; set; }

        public CommandeRevue(string id, DateTime dateCommande, double montant,
            DateTime dateFinAbonnement, string idRevue)
        {
            this.Id = id;
            this.DateCommande = dateCommande;
            this.Montant = montant;
            this.DateFinAbonnement = dateFinAbonnement;
            this.IdRevue = idRevue;
        }
    }
}