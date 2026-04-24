using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaTekDocuments.model;
using MediaTekDocuments.view;

namespace MediaTekDocuments.Tests
{
    [TestClass]
    public class TestsModels
    {
        #region Tests ParutionDansAbonnement
        [TestMethod]
        public void ParutionDansAbonnement_DateDansIntervalle_RetourneVrai()
        {
            DateTime dateCommande = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Local);
            DateTime dateFinAbonnement = new DateTime(2024, 12, 31, 0, 0, 0, DateTimeKind.Local);
            DateTime dateParution = new DateTime(2024, 6, 15, 0, 0, 0, DateTimeKind.Local);
            Assert.IsTrue(FrmMediatek.ParutionDansAbonnement(dateCommande, dateFinAbonnement, dateParution));
        }

        [TestMethod]
        public void ParutionDansAbonnement_DateAvantIntervalle_RetourneFaux()
        {
            DateTime dateCommande = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Local);
            DateTime dateFinAbonnement = new DateTime(2024, 12, 31, 0, 0, 0, DateTimeKind.Local);
            DateTime dateParution = new DateTime(2023, 12, 31, 0, 0, 0, DateTimeKind.Local);
            Assert.IsFalse(FrmMediatek.ParutionDansAbonnement(dateCommande, dateFinAbonnement, dateParution));
        }

        [TestMethod]
        public void ParutionDansAbonnement_DateApresIntervalle_RetourneFaux()
        {
            DateTime dateCommande = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Local);
            DateTime dateFinAbonnement = new DateTime(2024, 12, 31, 0, 0, 0, DateTimeKind.Local);
            DateTime dateParution = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Local);
            Assert.IsFalse(FrmMediatek.ParutionDansAbonnement(dateCommande, dateFinAbonnement, dateParution));
        }

        [TestMethod]
        public void ParutionDansAbonnement_DateEgaleDebut_RetourneVrai()
        {
            DateTime dateCommande = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Local);
            DateTime dateFinAbonnement = new DateTime(2024, 12, 31, 0, 0, 0, DateTimeKind.Local);
            Assert.IsTrue(FrmMediatek.ParutionDansAbonnement(dateCommande, dateFinAbonnement, dateCommande));
        }

        [TestMethod]
        public void ParutionDansAbonnement_DateEgaleFin_RetourneVrai()
        {
            DateTime dateCommande = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Local);
            DateTime dateFinAbonnement = new DateTime(2024, 12, 31, 0, 0, 0, DateTimeKind.Local);
            Assert.IsTrue(FrmMediatek.ParutionDansAbonnement(dateCommande, dateFinAbonnement, dateFinAbonnement));
        }
        #endregion

        #region Tests Livre
        [TestMethod]
        public void Livre_Constructeur_ProprietesBienInitialisees()
        {
            Livre livre = new Livre("00017", "Catastrophes au Brésil", "", "", "Philippe Masson", "",
                "10014", "Policier", "00004", "Ados", "JN002", "Jeunesse romans");
            Assert.AreEqual("00017", livre.Id);
            Assert.AreEqual("Philippe Masson", livre.Auteur);
            Assert.AreEqual("Catastrophes au Brésil", livre.Titre);
            Assert.AreEqual("Policier", livre.Genre);
            Assert.AreEqual("Ados", livre.Public);
            Assert.AreEqual("Jeunesse romans", livre.Rayon);
        }
        #endregion

        #region Tests Dvd
        [TestMethod]
        public void Dvd_Constructeur_ProprietesBienInitialisees()
        {
            Dvd dvd = new Dvd("00001", "Jurassic Park", "", 120, "Steven Spielberg", "",
                "10001", "Science-fiction", "00001", "Adultes", "CI001", "Cinéma");
            Assert.AreEqual("00001", dvd.Id);
            Assert.AreEqual(120, dvd.Duree);
            Assert.AreEqual("Steven Spielberg", dvd.Realisateur);
            Assert.AreEqual("Jurassic Park", dvd.Titre);
        }
        #endregion

        #region Tests Revue
        [TestMethod]
        public void Revue_Constructeur_ProprietesBienInitialisees()
        {
            Revue revue = new Revue("10001", "Arts Magazine", "", "10001", "Art",
                "00001", "Adultes", "RA001", "Arts", "Mensuelle", 7);
            Assert.AreEqual("10001", revue.Id);
            Assert.AreEqual("Mensuelle", revue.Periodicite);
            Assert.AreEqual("Arts Magazine", revue.Titre);
            Assert.AreEqual(7, revue.DelaiMiseADispo);
        }
        #endregion

        #region Tests Exemplaire
        [TestMethod]
        public void Exemplaire_Constructeur_ProprietesBienInitialisees()
        {
            DateTime dateAchat = new DateTime(2024, 1, 15, 0, 0, 0, DateTimeKind.Local);
            Exemplaire exemplaire = new Exemplaire(1, dateAchat, "", "00001", "10001");
            Assert.AreEqual(1, exemplaire.Numero);
            Assert.AreEqual(dateAchat, exemplaire.DateAchat);
            Assert.AreEqual("00001", exemplaire.IdEtat);
            Assert.AreEqual("10001", exemplaire.Id);
        }
        #endregion

        #region Tests CommandeDocument
        [TestMethod]
        public void CommandeDocument_Constructeur_ProprietesBienInitialisees()
        {
            DateTime dateCommande = new DateTime(2024, 3, 1, 0, 0, 0, DateTimeKind.Local);
            CommandeDocument commande = new CommandeDocument("20240301120000", dateCommande,
                150.50, 3, "00017", "00001", "en cours");
            Assert.AreEqual("20240301120000", commande.Id);
            Assert.AreEqual(dateCommande, commande.DateCommande);
            Assert.AreEqual(150.50, commande.Montant);
            Assert.AreEqual(3, commande.NbExemplaire);
            Assert.AreEqual("00017", commande.IdLivreDvd);
            Assert.AreEqual("00001", commande.IdSuivi);
            Assert.AreEqual("en cours", commande.Suivi);
        }
        #endregion

        #region Tests CommandeRevue
        [TestMethod]
        public void CommandeRevue_Constructeur_ProprietesBienInitialisees()
        {
            DateTime dateCommande = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Local);
            DateTime dateFinAbonnement = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Local);
            CommandeRevue commande = new CommandeRevue("20240101000000", dateCommande,
                25.0, dateFinAbonnement, "10001");
            Assert.AreEqual("20240101000000", commande.Id);
            Assert.AreEqual(dateCommande, commande.DateCommande);
            Assert.AreEqual(25.0, commande.Montant);
            Assert.AreEqual(dateFinAbonnement, commande.DateFinAbonnement);
            Assert.AreEqual("10001", commande.IdRevue);
        }
        #endregion

        #region Tests Utilisateur
        [TestMethod]
        public void Utilisateur_Constructeur_ProprietesBienInitialisees()
        {
            Utilisateur utilisateur = new Utilisateur("admin", "admin123", "00001", "Administratif");
            Assert.AreEqual("admin", utilisateur.Login);
            Assert.AreEqual("admin123", utilisateur.Pwd);
            Assert.AreEqual("00001", utilisateur.IdService);
            Assert.AreEqual("Administratif", utilisateur.Service);
        }
        #endregion

        #region Tests Service
        [TestMethod]
        public void Service_Constructeur_ProprietesBienInitialisees()
        {
            Service service = new Service("00001", "Administratif");
            Assert.AreEqual("00001", service.Id);
            Assert.AreEqual("Administratif", service.Libelle);
        }

        [TestMethod]
        public void Service_ToString_RetourneLibelle()
        {
            Service service = new Service("00001", "Administratif");
            Assert.AreEqual("Administratif", service.ToString());
        }
        #endregion

        #region Tests Suivi
        [TestMethod]
        public void Suivi_Constructeur_ProprietesBienInitialisees()
        {
            Suivi suivi = new Suivi("00001", "en cours");
            Assert.AreEqual("00001", suivi.Id);
            Assert.AreEqual("en cours", suivi.Libelle);
        }

        [TestMethod]
        public void Suivi_ToString_RetourneLibelle()
        {
            Suivi suivi = new Suivi("00001", "en cours");
            Assert.AreEqual("en cours", suivi.ToString());
        }
        #endregion
    }
}