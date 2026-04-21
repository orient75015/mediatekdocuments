using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MediaTekDocuments.model;

namespace MediaTekDocuments.view
{
    public partial class FrmAlerteAbonnements : Form
    {
        public FrmAlerteAbonnements(List<CommandeRevue> abonnements)
        {
            InitializeComponent();
            foreach (CommandeRevue abonnement in abonnements)
            {
                lstAbonnements.Items.Add(abonnement.Titre + " - fin le " +
                    abonnement.DateFinAbonnement.ToString("dd/MM/yyyy"));
            }
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}