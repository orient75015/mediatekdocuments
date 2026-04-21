using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaTekDocuments.view;

namespace MediaTekDocuments.Tests
{
    [TestClass]
    public class TestParutionDansAbonnement
    {
        [TestMethod]
        public void ParutionDansAbonnement_DateDansIntervalle_RetourneVrai()
        {
            DateTime dateCommande = new DateTime(2024, 1, 1);
            DateTime dateFinAbonnement = new DateTime(2024, 12, 31);
            DateTime dateParution = new DateTime(2024, 6, 15);
            bool resultat = FrmMediatek.ParutionDansAbonnement(dateCommande, dateFinAbonnement, dateParution);
            Assert.IsTrue(resultat);
        }

        [TestMethod]
        public void ParutionDansAbonnement_DateAvantIntervalle_RetourneFaux()
        {
            DateTime dateCommande = new DateTime(2024, 1, 1);
            DateTime dateFinAbonnement = new DateTime(2024, 12, 31);
            DateTime dateParution = new DateTime(2023, 12, 31);
            bool resultat = FrmMediatek.ParutionDansAbonnement(dateCommande, dateFinAbonnement, dateParution);
            Assert.IsFalse(resultat);
        }

        [TestMethod]
        public void ParutionDansAbonnement_DateApresIntervalle_RetourneFaux()
        {
            DateTime dateCommande = new DateTime(2024, 1, 1);
            DateTime dateFinAbonnement = new DateTime(2024, 12, 31);
            DateTime dateParution = new DateTime(2025, 1, 1);
            bool resultat = FrmMediatek.ParutionDansAbonnement(dateCommande, dateFinAbonnement, dateParution);
            Assert.IsFalse(resultat);
        }

        [TestMethod]
        public void ParutionDansAbonnement_DateEgaleDebut_RetourneVrai()
        {
            DateTime dateCommande = new DateTime(2024, 1, 1);
            DateTime dateFinAbonnement = new DateTime(2024, 12, 31);
            DateTime dateParution = new DateTime(2024, 1, 1);
            bool resultat = FrmMediatek.ParutionDansAbonnement(dateCommande, dateFinAbonnement, dateParution);
            Assert.IsTrue(resultat);
        }

        [TestMethod]
        public void ParutionDansAbonnement_DateEgaleFin_RetourneVrai()
        {
            DateTime dateCommande = new DateTime(2024, 1, 1);
            DateTime dateFinAbonnement = new DateTime(2024, 12, 31);
            DateTime dateParution = new DateTime(2024, 12, 31);
            bool resultat = FrmMediatek.ParutionDansAbonnement(dateCommande, dateFinAbonnement, dateParution);
            Assert.IsTrue(resultat);
        }
    }
}