using System;
using System.Windows.Forms;
using MediaTekDocuments.view;
using MediaTekDocuments.controller;

namespace MediaTekDocuments
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FrmConnexion frmConnexion = new FrmConnexion();
            if (frmConnexion.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new FrmMediatek(frmConnexion.UtilisateurConnecte));
            }
        }
    }
}