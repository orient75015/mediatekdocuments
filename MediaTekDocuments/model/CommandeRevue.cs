using System;

namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier CommandeRevue (abonnement ou renouvellement d'une revue)
    /// </summary>
    public class CommandeRevue
    {
        /// <summary>Identifiant de la commande</summary>
        public string Id { get; set; }

        /// <summary>Date de la commande</summary>
        public DateTime DateCommande { get; set; }

        /// <summary>Montant de la commande</summary>
        public double Montant { get; set; }

        /// <summary>Date de fin d'abonnement</summary>
        public DateTime DateFinAbonnement { get; set; }

        /// <summary>Identifiant de la revue</summary>
        public string IdRevue { get; set; }

        /// <summary>Titre de la revue</summary>
        public string Titre { get; set; }

        /// <summary>
        /// Constructeur de la classe CommandeRevue
        /// </summary>
        /// <param name="id">Identifiant de la commande</param>
        /// <param name="dateCommande">Date de la commande</param>
        /// <param name="montant">Montant de la commande</param>
        /// <param name="dateFinAbonnement">Date de fin d'abonnement</param>
        /// <param name="idRevue">Identifiant de la revue</param>
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