namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Suivi (stade d'une commande)
    /// </summary>
    public class Suivi
    {
        public string Id { get; set; }
        public string Libelle { get; set; }

        public Suivi(string id, string libelle)
        {
            this.Id = id;
            this.Libelle = libelle;
        }

        public override string ToString()
        {
            return this.Libelle;
        }
    }
}