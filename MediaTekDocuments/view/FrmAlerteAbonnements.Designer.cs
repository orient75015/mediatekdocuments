namespace MediaTekDocuments.view
{
    partial class FrmAlerteAbonnements
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lstAbonnements = new System.Windows.Forms.ListBox();
            this.lblTitre = new System.Windows.Forms.Label();
            this.btnFermer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitre.Location = new System.Drawing.Point(12, 12);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Text = "Abonnements expirant dans moins de 30 jours :";
            this.lstAbonnements.Location = new System.Drawing.Point(12, 40);
            this.lstAbonnements.Name = "lstAbonnements";
            this.lstAbonnements.Size = new System.Drawing.Size(460, 200);
            this.lstAbonnements.TabIndex = 0;
            this.btnFermer.Location = new System.Drawing.Point(200, 255);
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.Size = new System.Drawing.Size(90, 27);
            this.btnFermer.Text = "Fermer";
            this.btnFermer.UseVisualStyleBackColor = true;
            this.btnFermer.Click += new System.EventHandler(this.btnFermer_Click);
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 295);
            this.Controls.Add(this.lblTitre);
            this.Controls.Add(this.lstAbonnements);
            this.Controls.Add(this.btnFermer);
            this.Name = "FrmAlerteAbonnements";
            this.Text = "Alerte abonnements";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ListBox lstAbonnements;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Button btnFermer;
    }
}