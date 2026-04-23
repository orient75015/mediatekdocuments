using System;
using System.Windows.Forms;
using MediaTekDocuments.model;
using MediaTekDocuments.controller;

namespace MediaTekDocuments.view
{
    /// <summary>
    /// Fenêtre d'authentification
    /// </summary>
    public partial class FrmConnexion : Form
    {
        private readonly FrmMediatekController controller;
        public Utilisateur UtilisateurConnecte { get; private set; }

        public FrmConnexion()
        {
            InitializeComponent();
            controller = new FrmMediatekController();
        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            if (txbLogin.Text.Equals("") || txbPwd.Text.Equals(""))
            {
                MessageBox.Show("Veuillez saisir un login et un mot de passe", "Information");
                return;
            }
            Utilisateur utilisateur = controller.GetUtilisateur(txbLogin.Text, txbPwd.Text);
            if (utilisateur == null)
            {
                MessageBox.Show("Login ou mot de passe incorrect", "Erreur");
                txbPwd.Text = "";
                txbLogin.Focus();
                return;
            }
            UtilisateurConnecte = utilisateur;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}